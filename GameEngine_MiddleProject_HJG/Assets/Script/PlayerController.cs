using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpforce = 2f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int maxJumpCount = 2;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool Invincible = false;
    private float moveInput;
    private Animator pAni;

    private int currentJumpCount = 0;  // 현재 점프를 한 횟수 추적

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pAni = GetComponent<Animator>();
    }
    private void Update()
    {
        // 1. 이동 처리
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);


        if(Invincible)
        {
            if (moveInput > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if (moveInput < 0)
                transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            // 2. 캐릭터 진행 방향에 따라 좌우 반전
            if (moveInput > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if (moveInput < 0)
                transform.localScale = new Vector3(-1, 1, 1);
        }

        // 3. 바닥 체크
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.05f, groundLayer);

        // 4. 땅에 닿아있고, 캐릭터가 위로 솟구치는 상태가 아닐 때 점프 횟수 초기화
        if (isGrounded && rb.linearVelocity.y <= 0.1f)
        {
            currentJumpCount = 0;
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveInput = input.x;
    }

    public void OnJump(InputValue value)
    {
        // 버튼이 눌렸고, 현재 점프 횟수가 최대 점프 횟수(2)보다 작을 때만 점프 실행
        if (value.isPressed && currentJumpCount < maxJumpCount)
        {
            // 점프 전 y축 속도를 0으로 초기화 (떨어지는 중이거나 2단 점프 시 높이를 일정하게 보장)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            pAni.SetTrigger("Jump");

            currentJumpCount++; // 점프 횟수 1 증가
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn")) 
        {
            if (Invincible == false)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        if (collision.CompareTag("Finish"))
        {
            collision.GetComponent<LevelObject>().MoveToNextLevel();
        }

        if (collision.CompareTag("Enemy"))
        {
            if(Invincible)
                Destroy(collision.gameObject);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(collision.CompareTag("Invincible_Item"))
        {
            Invincible = true;
            Invoke(nameof(ResetInvincible_Item), 3f);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Speed_Item"))
        {
            moveSpeed *= 1.5f;
            Invoke(nameof(Speed_Item), 3f);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Jump_Item"))
        {
            jumpforce *= 1.5f;
            Invoke(nameof(Speed_Item), 3f);
            Destroy(collision.gameObject);
        }

    }
        void ResetInvincible_Item()
        {
            Invincible = false;
        }
        void Speed_Item()
        {
            moveSpeed = 2f;
        }
        void Jump_Item()
        {
            jumpforce = 2f;
        }

}

