using UnityEngine;

public class BallBounce : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float paddleY = collision.transform.position.y;
            float contactY = transform.position.y;

            float offset = contactY - paddleY;
            float normalized = offset / collision.collider.bounds.size.y;

            Vector2 direction = new Vector2(rb.velocity.x, normalized).normalized;
            rb.velocity = direction * rb.velocity.magnitude;
        }
    }
}