using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 7f;
    private Vector2 direction;
    public GameManager gameManager;

    void Start()
    {
        ResetBall();
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y > 4.5f || transform.position.y < -4.5f)
        {
            direction.y = -direction.y;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GoalLeft"))
        {
            gameManager.OnGoalScored(true);
        }
        else if (other.CompareTag("GoalRight"))
        {
            gameManager.OnGoalScored(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float yOffset = transform.position.y - collision.transform.position.y;
            direction = new Vector2(-direction.x, yOffset).normalized;

            var ai = collision.gameObject.GetComponent<AIPaddle>();
            if (ai != null)
            {
                ai.LearnFromHit(transform.position.y);
            }
        }
    }

    public void ResetBall()
    {
        transform.position = Vector2.zero;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-0.5f, 0.5f);
        direction = new Vector2(x, y).normalized;
    }

    public Vector2 GetDirection()
    {
        return direction;
    }
}