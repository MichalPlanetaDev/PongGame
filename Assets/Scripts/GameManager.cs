using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallController ball;
    public AIPaddle ai;
    public PlayerPaddle player;

    private int playerScore = 0;
    private int botScore = 0;

    public void OnGoalScored(bool playerScored)
    {
        if (playerScored)
        {
            playerScore++;
            Debug.Log("Player scored: " + playerScore);

            ai.speed += 0.5f;
            Debug.Log("AI speed increased to: " + ai.speed);
        }
        else
        {
            botScore++;
            Debug.Log("Bot scored: " + botScore);
        }

        ball.ResetBall();
    }
}