using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float walkSpeed, maxWalkSpeed, runSpeed, maxRunSpeed, hInput;

    bool isRunning;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        isRunning = Input.GetButton("Sprint");
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    //move player in direction pressed, if the run key is pressed, move by run speed
    void Move()
    {
        if (isRunning)
        {
            run();
        }
        else
        {
            walk();
        }
    }

    void walk()
    {
        if (hInput > 0 && Mathf.Abs(rb.velocity.x) <= maxWalkSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x + walkSpeed, rb.velocity.y);
        }
        else if (hInput < 0 && Mathf.Abs(rb.velocity.x) <= maxWalkSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x - walkSpeed, rb.velocity.y);
        }
        else if (hInput != 0 && rb.velocity.x > maxWalkSpeed)
        {
            rb.velocity = new Vector2(maxWalkSpeed, rb.velocity.y);
        }
        else if (hInput != 0 && rb.velocity.x < -maxWalkSpeed)
        {
            rb.velocity = new Vector2(-maxWalkSpeed, rb.velocity.y);
        }
    }

    void run()
    {
        if (hInput > 0 && Mathf.Abs(rb.velocity.x) <= maxRunSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x + runSpeed, rb.velocity.y);
        }
        else if (hInput < 0 && Mathf.Abs(rb.velocity.x) <= maxRunSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x - runSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x > maxRunSpeed)
        {
            rb.velocity = new Vector2(maxRunSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x < -maxRunSpeed)
        {
            rb.velocity = new Vector2(-maxRunSpeed, rb.velocity.y);
        }
    }

    //if player is on ground and presses the jump key, jump
    void Jump()
    {
        //jump script
    }
}
