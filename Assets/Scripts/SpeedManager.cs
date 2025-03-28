using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public static SpeedManager Instance { get; private set; } // Singleton for global access

    public float initialSpeed = 7f; // Initial speed for ground
    public float maxMultiplier = 3f; // Maximum speed multiplier for ground
    public float speedIncreaseRate = 0.1f; // Speed increase per second for ground

    public float initialBackgroundSpeed = 1f; // Initial background speed
    public float maxBackgroundSpeed = 3f; // Maximum background speed
    public float backgroundSpeedIncreaseRate = 0.1f; // Speed increase per second for background

    private float currentSpeed;
    private float currentBackgroundSpeed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ensures the manager persists across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    private void Start()
    {
        currentSpeed = initialSpeed;
        currentBackgroundSpeed = initialBackgroundSpeed;
    }

    private void Update()
    {
        // Increase ground speed linearly over time
        if (currentSpeed < initialSpeed * maxMultiplier)
        {
            currentSpeed += speedIncreaseRate * Time.deltaTime;
        }

        // Increase background speed linearly over time
        if (currentBackgroundSpeed < maxBackgroundSpeed)
        {
            currentBackgroundSpeed += backgroundSpeedIncreaseRate * Time.deltaTime;
        }

        // Move the background elements using the current background speed
        MoveBackgrounds();
    }

    private void MoveBackgrounds()
    {
        // Get all background objects in the scene and move them along the Z-axis
        GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("Background");
        foreach (GameObject background in backgrounds)
        {
            background.transform.Translate(Vector3.back * currentBackgroundSpeed * Time.deltaTime);
        }
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public float GetCurrentBackgroundSpeed()
    {
        return currentBackgroundSpeed;
    }

    public void ResetSpeed()
    {
        currentSpeed = initialSpeed; // Reset to initial speed for ground
        currentBackgroundSpeed = initialBackgroundSpeed; // Reset to initial speed for background
    }
}
