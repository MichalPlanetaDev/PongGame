using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public Transform ball;     // Reference to the ball
    public float speed = 6f;

    private void Update()
    {
        if (ball == null)
            return;

        // Move up if ball is above, move down if below
        if (ball.position.y > transform.position.y)
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        else if (ball.position.y < transform.position.y)
            transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}