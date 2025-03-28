using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody rb;

    // Jump and gravity settings
    public float baseJumpSpeed = 22f; // Initial jump speed
    public float maxJumpSpeed = 44f; // Maximum jump speed
    public float baseGravityScale = 5f; // Initial gravity scale
    public float maxGravityScale = 23f; // Maximum gravity scale
    private float jumpSpeed; // Current jump speed (updated dynamically)
    private float gravityScale; // Current gravity scale (updated dynamically)

    private AudioSource jumpSound;     // AudioSource for the jump sound
    private AudioSource gameOverSound; // AudioSource for the game-over sound
    public float groundCheckDistance = 0.2f; // Distance for ground check
    public LayerMask Ground; // Layer for ground detection
    private bool isGrounded; // Whether the player is on the ground
    private int jumpCount = 0; // Counter to track the number of jumps
    private int maxJumps = 1; // Maximum number of jumps allowed

    private void Start()
    {
        // Initialize jump speed and gravity scale with base values
        jumpSpeed = baseJumpSpeed;
        gravityScale = baseGravityScale;

        // Get the jump sound from the child at position 0
        jumpSound = transform.GetChild(0).GetComponent<AudioSource>();

        // Get the game-over sound from the child at position 1
        gameOverSound = transform.GetChild(1).GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Check if the player is on the ground using raycast
        isGrounded = Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, groundCheckDistance, Ground);

        // Reset jump count when the player is grounded
        if (isGrounded)
        {
            jumpCount = 0;
        }

        // Allow jumping only if the jump count is less than maxJumps
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpAction();
        }

        // Adjust jumpSpeed and gravityScale based on SpeedManager's speed
        AdjustJumpAndGravity();
    }

    private void FixedUpdate()
    {
        // Add custom gravity
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player hits an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Play game-over sound
            if (gameOverSound != null)
                gameOverSound.Play();

            // Call the Game Over method in GameManager
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    private void JumpAction()
    {
        // Reset Y velocity to ensure consistent jumping
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        // Apply the jump force
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode.Impulse);

        // Increment the jump count
        jumpCount++;

        // Play the jump sound
        if (jumpSound != null)
            jumpSound.Play();
    }

    private void AdjustJumpAndGravity()
    {
        if (SpeedManager.Instance != null)
        {
            float currentSpeed = SpeedManager.Instance.GetCurrentSpeed();
            float initialSpeed = SpeedManager.Instance.initialSpeed;
            float maxSpeed = initialSpeed * SpeedManager.Instance.maxMultiplier;

            // Calculate the interpolation factor (0 to 1)
            float t = Mathf.Clamp01((currentSpeed - initialSpeed) / (maxSpeed - initialSpeed));

            // Linearly interpolate jumpSpeed and gravityScale
            jumpSpeed = Mathf.Lerp(baseJumpSpeed, maxJumpSpeed, t);
            gravityScale = Mathf.Lerp(baseGravityScale, maxGravityScale, t);
        }
    }
}
