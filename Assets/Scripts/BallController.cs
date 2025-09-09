using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 7f;
    private Rigidbody2D rb;

    [System.Obsolete]
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    [System.Obsolete]
    private void LaunchBall()
    {
        // Random direction X: -1 or 1
        float dirX = Random.Range(0, 2) == 0 ? -1f : 1f;
        float dirY = Random.Range(-0.5f, 0.5f);

        Vector2 direction = new Vector2(dirX, dirY).normalized;
        rb.velocity = direction * speed;
    }

    [System.Obsolete]
    public void StopBall()
    {
        rb.velocity = Vector2.zero;
    }
}