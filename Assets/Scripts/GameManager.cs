using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // To access UI components like Text

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text finalScoreText;  // Text UI to display the final score
    public ScoreManager scoreManager;  // Reference to the ScoreManager to get the score

    // UI elements to hide once the game starts
    public GameObject uiElementToHide; // Reference to the UI element to hide after the game starts

    // References to audio sources
    public AudioSource gameOverAudio;
    public AudioSource F_bg;
    public AudioSource F_running;

    private bool gameStarted = false; // Track whether the game has started

    private void Start()
    {
        // Attempt to assign background and footstep audio
        GameObject backgroundAudioObject = GameObject.FindGameObjectWithTag("backgroundAudio");
        GameObject footstepAudioObject = GameObject.FindGameObjectWithTag("footstepAudio");

        if (backgroundAudioObject != null)
            F_bg = backgroundAudioObject.GetComponent<AudioSource>();

        if (footstepAudioObject != null)
            F_running = footstepAudioObject.GetComponent<AudioSource>();

        // Pause the game initially
        Time.timeScale = 0f;
        Debug.Log("Game Paused: Press Space to Start.");
    }

    private void Update()
    {
        // Check if the game has not started and spacebar is pressed
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        gameStarted = true;
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

        // Show the Game Over screen
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
            Debug.Log("Game Over Screen Activated.");
        }

        // Update the final score text
        if (scoreManager != null && finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + Mathf.FloorToInt(scoreManager.GetScore()).ToString();
            Debug.Log("Final Score Updated.");
        }

        // Deactivate the top-right score display
        if (scoreManager != null)
            scoreManager.GameOver(); // Let ScoreManager handle its own UI logic

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
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the scene
        Debug.Log("Game Restarted.");
    }
}
