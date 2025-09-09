using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public Transform ball;
    public float speed = 5f;
    public float reactionZone = 3f;

    private BallController ballController;

    private void Start()
    {
        if (ball != null)
        {
            ballController = ball.GetComponent<BallController>();
        }
    }

    private void Update()
    {
        if (ball == null || ballController == null)
            return;

        Vector2 ballDir = ballController.GetDirection();

        if (ballDir.x < 0f && ball.position.x < -reactionZone)
        {
            float direction = Mathf.Sign(ball.position.y - transform.position.y);
            transform.Translate(Vector2.up * direction * speed * Time.deltaTime);
        }
    }

    public void LearnFromHit(float contactY)
    {

    }
}