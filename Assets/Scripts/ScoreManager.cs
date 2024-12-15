using UnityEngine;
using UnityEngine.UI; // For UI Text component

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Reference to the UI Text component that displays the score
    public Text gameOverScoreText; // Reference to the UI Text component for center score display

    private float score = 0f; // The current score
    private bool isGameOver = false; // To track if the game is over

    void Start()
    {
        // Make sure the score is at 0 when the game starts
        score = 0f;

        // Ensure gameOverScoreText is initially hidden
        if (gameOverScoreText != null)
            gameOverScoreText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver)
        {
            // Increase score over time (you can adjust the speed of the score increase)
            score += Time.deltaTime * 8;

            // Update the UI Text component with the current score
            scoreText.text = Mathf.FloorToInt(score).ToString();
        }
    }

    // Call this method to stop the score counter when the game is over
    public void GameOver()
    {
        isGameOver = true;

        // Deactivate top-right score text
        if (scoreText != null)
            scoreText.gameObject.SetActive(false);

        // Display the score in the center
        if (gameOverScoreText != null)
        {
            gameOverScoreText.gameObject.SetActive(true);
            gameOverScoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }

    // This method gets the current score
    public float GetScore()
    {
        return score;
    }
}
