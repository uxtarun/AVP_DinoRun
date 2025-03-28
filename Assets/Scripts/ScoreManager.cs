using UnityEngine;
using UnityEngine.UI; // For UI Text component

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Reference to the UI Text component that displays the current score
    public Text gameOverScoreText; // Reference to the UI Text component for center score display
    public Text highScoreText; // Reference to the UI Text component to display the high score

    private float score = 0f; // The current score
    private bool isGameOver = false; // To track if the game is over
    private int highScore = 0; // The high score

    void Start()
    {
        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Update the high score UI at the start of the game
        if (highScoreText != null)
        {
            highScoreText.text = "The OG Gamer: " + highScore.ToString();
        }

        // Reset the current score and hide gameOverScoreText
        score = 0f;

        if (gameOverScoreText != null)
        {
            gameOverScoreText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Press R to reset high score
        {
            ResetHighScore();
        }
        if (!isGameOver)
        {
            // Increase score over time (adjust the multiplier for score speed)
            score += Time.deltaTime * 8;

            // Update the current score UI
            if (scoreText != null)
            {
                scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
            }
        }
    }

    public void GameOver()
    {
        isGameOver = true;

        // Deactivate the top-right score text
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(false);
        }

        // Display the final score in the center
        if (gameOverScoreText != null)
        {
            gameOverScoreText.gameObject.SetActive(true);
            gameOverScoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }

        // Check if the current score is a new high score
        if (Mathf.FloorToInt(score) > highScore)
        {
            highScore = Mathf.FloorToInt(score);

            // Save the new high score to PlayerPrefs
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // Ensure the high score is saved

            Debug.Log("New High Score: " + highScore);

            // Update the high score UI
            if (highScoreText != null)
            {
                highScoreText.text = "High Score: " + highScore.ToString();
            }
        }
    }

    // This method gets the current score
    public float GetScore()
    {
        return score;
    }

    // This method gets the high score
    public int GetHighScore()
    {
        return highScore;
    }

    // Call this method if you want to reset the high score (e.g., for testing purposes)
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = 0;

        // Update the high score UI
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: 0";
        }

        Debug.Log("High Score Reset.");
    }
}
