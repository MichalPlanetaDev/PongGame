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

    private float clampY = 4.5f;

    private void Update()
    {
        if (ball == null || ballController == null)
            return;

        Vector2 ballDir = ballController.GetDirection();

        if (ballDir.x < 0f && ball.position.x < -reactionZone)
        {
            float direction = Mathf.Sign(ball.position.y - transform.position.y);
            Vector3 nextPos = transform.position + Vector3.up * direction * speed * Time.deltaTime;

            nextPos.y = Mathf.Clamp(nextPos.y, -clampY, clampY);

            transform.position = nextPos;
        }
    }


    public void LearnFromHit(float contactY)
    {

    }
}