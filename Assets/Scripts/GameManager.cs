using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text finalScoreText; // Text UI to display the final score
    public ScoreManager scoreManager; // Reference to the ScoreManager to get the score

    // UI elements to hide once the game starts
    public GameObject uiElementToHide;

    // References to audio sources
    public AudioSource gameOverAudio;
    public AudioSource F_bg;
    public AudioSource F_running;

    private bool gameStarted = false; // Track whether the game has started
    private bool isGameOver = false; // Track whether the game is over

    private bool isPaused = true; // Track whether the game is in a paused state

    private void Start()
    {
        if (isPaused)
        {
            // Pause the game initially
            Time.timeScale = 0f;
            Debug.Log("Game Paused: Press Space to Start.");
        }

        // Attempt to assign background and footstep audio
        GameObject backgroundAudioObject = GameObject.FindGameObjectWithTag("backgroundAudio");
        GameObject footstepAudioObject = GameObject.FindGameObjectWithTag("footstepAudio");

        if (backgroundAudioObject != null)
            F_bg = backgroundAudioObject.GetComponent<AudioSource>();

        if (footstepAudioObject != null)
            F_running = footstepAudioObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!gameStarted && !isGameOver && Input.GetKeyDown(KeyCode.Space)) // Only start if game is not over
        {
            StartGame();
        }
        else if (isGameOver && Input.GetKeyDown(KeyCode.Space)) // Space after game over to restart the game
        {
            RestartGame();
        }
    }

    private void StartGame()
    {
        gameStarted = true;
        isGameOver = false; // Reset game over state
        isPaused = false; // Set the game state as unpaused
        Time.timeScale = 1f; // Resume the game

        // Hide the UI element once the game starts
        if (uiElementToHide != null)
        {
            uiElementToHide.SetActive(false);
            Debug.Log("UI Element hidden after game start.");
        }

        // Play background and footstep audios
        if (F_bg != null && !F_bg.isPlaying)
            F_bg.Play();

        if (F_running != null && !F_running.isPlaying)
            F_running.Play();

        Debug.Log("Game Started.");
    }

    public void GameOver()
    {
        Debug.Log("Game Over triggered!");
        gameStarted = false;
        isGameOver = true; // Set game over state

        // Show the Game Over screen
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
            Debug.Log("Game Over Screen Activated.");
        }

        // Update the final score text
        if (scoreManager != null && finalScoreText != null)
        {
            finalScoreText.gameObject.SetActive(true);
            finalScoreText.text = "Final Score: " + Mathf.FloorToInt(scoreManager.GetScore()).ToString();
            Debug.Log("Final Score Updated." + Mathf.FloorToInt(scoreManager.GetScore()).ToString());
            Debug.Log("Is active? " + finalScoreText.gameObject.activeSelf);

        }

        // Deactivate the top-right score display
        if (scoreManager != null)
            scoreManager.GameOver();

        // Stop background and footstep audios
        if (F_bg != null && F_bg.isPlaying)
            F_bg.Stop();

        if (F_running != null && F_running.isPlaying)
            F_running.Stop();

        // Play game-over audio
        if (gameOverAudio != null && !gameOverAudio.isPlaying)
            gameOverAudio.Play();

        Time.timeScale = 0f; // Pause the game
    }

    public void RestartGame()
    {
        Debug.Log("Restarting Game...");

        // Reset SpeedManager to its default values
        if (SpeedManager.Instance != null)
        {
            SpeedManager.Instance.ResetSpeed();
        }

        // Reset game state
        gameStarted = false;
        isGameOver = false;
        isPaused = true;

        // Resume time and reload the scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Game Restarted.");
    }
}
