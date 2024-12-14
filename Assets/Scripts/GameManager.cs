using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // To access UI components like Text


public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text finalScoreText;  // Text UI to display the final score
    public ScoreManager scoreManager;  // Reference to the ScoreManager to get the score
    public AudioSource gameOverSound;


    public void GameOver()
    {
        if (gameOverSound != null)
        {
            gameOverSound.Play();
        }
        // Show the Game Over screen
        gameOverScreen.SetActive(true);
        Debug.Log("Game Over triggered!");
        finalScoreText.text = "Final Score: " + Mathf.FloorToInt(scoreManager.GetScore()).ToString();


        Debug.Log("Game Over Screen Active: " + gameOverScreen.activeSelf);

        // Stop the game (optional)
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Restart the game by reloading the scene
        Time.timeScale = 1f; // Reset time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
