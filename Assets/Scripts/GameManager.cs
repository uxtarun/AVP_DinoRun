using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    public void GameOver()
    {
        // Show the Game Over screen
        gameOverScreen.SetActive(true);
        Debug.Log("Game Over triggered!");

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
