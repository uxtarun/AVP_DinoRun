using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpSpeed;
    public float gravityScale;
    private AudioSource jumpSound;     // AudioSource for the jump sound
    private AudioSource gameOverSound; // AudioSource for the game-over sound

    private void Start()
    {
        // Get the jump sound from the child at position 0
        jumpSound = transform.GetChild(0).GetComponent<AudioSource>();

        // Get the game-over sound from the child at position 1
        gameOverSound = transform.GetChild(1).GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Play jump sound and apply force
            if (jumpSound != null)
                jumpSound.Play();

            rb.AddForce(Vector2.up * jumpSpeed, ForceMode.Impulse);
        }
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
}
