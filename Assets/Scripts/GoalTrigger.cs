using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public bool isLeftGoal = false;
    public BallController ball;

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ball"))
            return;

        if (isLeftGoal)
        {
            Debug.Log("Right player scored!");
        }
        else
        {
            Debug.Log("Left player (bot) scored!");
        }

        ball.ResetBall();
    }
}