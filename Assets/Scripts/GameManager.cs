using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public BallController ball;
    public AIPaddle ai;
    public PlayerPaddle player;
    public TextMeshProUGUI scoreText;

    private int playerScore = 0;
    private int botScore = 0;

    private void Start()
    {
        UpdateScoreText();
    }

    public void OnGoalScored(bool playerScored)
    {
        if (playerScored)
        {
            playerScore++;
            ai.speed += 0.5f;
        }
        else
        {
            botScore++;
        }

        UpdateScoreText();
        ball.ResetBall();
    }

    private void UpdateScoreText()
    {
        scoreText.text = botScore.ToString() + " : " + playerScore.ToString();
    }
}