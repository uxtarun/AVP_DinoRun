using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource jumpSound; 
    public float jumpSpeed;
    public float gravityScale;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode.Impulse);
            jumpSound.Play();
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player hits an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Call the Game Over method in GameManager
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
