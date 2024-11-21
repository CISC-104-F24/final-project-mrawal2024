using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float sprintMultiplier = 1.5f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirection = 0f;
        float speed = moveSpeed;

        // Movement keys
        if (Input.GetKey(KeyCode.A)) // Move left
        {
            moveDirection = -1f;
        }
        if (Input.GetKey(KeyCode.D)) // Move right
        {
            moveDirection = 1f;
        }

        // Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= sprintMultiplier;
        }

        // Apply horizontal movement
        rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);

        // Jump key
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }
}
