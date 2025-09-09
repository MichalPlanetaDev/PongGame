using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 7f;
    private Vector2 direction;

    void Start()
    {
        ResetBall();
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        // Bounce off top/bottom walls (Y axis)
        if (transform.position.y > 4.5f || transform.position.y < -4.5f)
        {
            direction.y = -direction.y;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GoalLeft"))
        {
            Debug.Log("Right player scored!");
            ResetBall();
        }
        else if (other.CompareTag("GoalRight"))
        {
            Debug.Log("Left player (bot) scored!");
            ResetBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float yOffset = transform.position.y - collision.transform.position.y;
            direction = new Vector2(-direction.x, yOffset).normalized;
        }
    }

    public void ResetBall()
    {
        transform.position = Vector2.zero;

        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-0.5f, 0.5f);

        direction = new Vector2(x, y).normalized;
    }
}