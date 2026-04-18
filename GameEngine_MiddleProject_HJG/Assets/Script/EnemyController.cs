using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 1.5f;

    private Rigidbody2D rb;
    private bool isMovingRight = true;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isMovingRight)
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        else 
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);

        Flip();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            isMovingRight = !isMovingRight;
        }
    }
    private void Flip()
    {

        // 현재 캐릭터의 크기(Scale) 값을 가져옴

        Vector3 localScale = transform.localScale;

        // 오른쪽으로 가고 있는데 Scale.x가 음수라면? 혹은 그 반대라면?

        if ((isMovingRight && localScale.x < 0) || (!isMovingRight && localScale.x > 0))
        {
            // X값에 -1을 곱해서 이미지를 반전

            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
