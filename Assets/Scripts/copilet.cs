using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copilet : MonoBehaviour
{
    // The speed of the player
    public float speed = 5f;

    // The force of the player's jump
    public float jumpForce = 10f;

    // The Rigidbody2D component
    private Rigidbody2D rb;

    // The horizontal input value
    private float horizontal;

    // A flag to indicate if the player is grounded
    private bool isGrounded;

    // The ground layer
    public LayerMask groundLayer;

    // The ground check radius
    public float groundCheckRadius = 0.2f;

    // The ground check transform
    public Transform groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input value
        horizontal = Input.GetAxis("Horizontal");

        // Flip the player's sprite depending on the input direction
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Check if the player presses the jump button
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply a force to the player's rigidbody
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    // FixedUpdate is called once per fixed timestep
    void FixedUpdate()
    {
        // Set the horizontal velocity of the player's rigidbody
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
}
