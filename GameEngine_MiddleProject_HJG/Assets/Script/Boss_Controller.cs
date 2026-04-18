using UnityEngine;

public class Boss_Controller : MonoBehaviour
{
    public float moveSpeed = .5f;
    public float raycastDistance = 0.5f;
    public float traceDistance = 0.1f;

    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (player == null) return;
        Vector2 direction = player.position - transform.position;

        Vector2 directionNormalized = direction.normalized;

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, directionNormalized, raycastDistance);
        Debug.DrawRay(transform.position, directionNormalized * raycastDistance, Color.red);

        foreach (RaycastHit2D rHit in hits)
        {
            if (rHit.collider != null && rHit.collider.CompareTag("Obstacle"))
            {
                Vector3 alternativeDirection = Quaternion.Euler(0f, 0f, -90f) * directionNormalized;
                transform.Translate(alternativeDirection * moveSpeed * Time.deltaTime);
            }

            else
            {
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
        }

    }
}
