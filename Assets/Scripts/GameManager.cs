using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // To access UI components like Text

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text finalScoreText;  // Text UI to display the final score
    public ScoreManager scoreManager;  // Reference to the ScoreManager to get the score

    // References to audio sources
    public AudioSource gameOverAudio; // Reference to the game_over AudioSource
    public AudioSource backgroundAudio; // Reference to the F_bg AudioSource
    public AudioSource runningAudio; // Reference to the F_running AudioSource

    private bool gameStarted = false;  // Track whether the game has started

    private void Start()
    {
        // Pause the game initially
        Time.timeScale = 0f;
        Debug.Log("Game Paused: Press Space to Start.");
    }

    private void Update()
    {
        // Check if the game is not started and spacebar is pressed
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        // Resume the game
        gameStarted = true;
        Time.timeScale = 1f;

        // Play background audio if it's not already playing
        if (!backgroundAudio.isPlaying)
        {
            backgroundAudio.Play();
        }

        Debug.Log("Game Started.");
    }

    public void GameOver()
    {
        // Show the Game Over screen
        gameOverScreen.SetActive(true);
        Debug.Log("Game Over triggered!");

        // Stop all relevant audio
        if (backgroundAudio.isPlaying)
        {
            backgroundAudio.Stop();
            Debug.Log("Background audio stopped.");
        }

        if (runningAudio.isPlaying)
        {
            runningAudio.Stop();
            Debug.Log("Running audio stopped.");
        }

        if (!gameOverAudio.isPlaying)
        {
            gameOverAudio.Play(); // Play game over sound once
            Debug.Log("Game Over audio played.");
        }

        // Update the final score text
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
