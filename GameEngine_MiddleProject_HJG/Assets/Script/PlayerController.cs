using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpforce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int maxJumpCount = 2;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;
    private Animator pAni;

    private int currentJumpCount = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pAni = GetComponent<Animator>();
    }
    private void Update()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.05f, groundLayer);

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
        if (value.isPressed && currentJumpCount < maxJumpCount)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            pAni.SetTrigger("Jump");

            currentJumpCount++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn")) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        SceneManager.LoadScene("Level_" + collision.name);
    }

}

