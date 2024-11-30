using UnityEngine;
using UnityEngine.UI; // For UI Text component

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Reference to the UI Text component that displays the score
    private float score = 0f; // The current score
    private bool isGameOver = false; // To track if the game is over

    void Start()
    {
        // Make sure the score is at 0 when the game starts
        score = 0f;
    }

    void Update()
    {
        if (!isGameOver)
        {
            // Increase score over time (you can adjust the speed of the score increase)
            score += Time.deltaTime * 4;

            // Update the UI Text component with the current score
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }

    // Call this method to stop the score counter when the game is over
    public void GameOver()
    {
        isGameOver = true;
    }

    // This method gets the current score
    public float GetScore()
    {
        return score;
    }
}