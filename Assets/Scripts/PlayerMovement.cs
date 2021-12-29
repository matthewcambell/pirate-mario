using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float walkSpeed, maxWalkSpeed, runSpeed, maxRunSpeed, hInput, baseJumpHeight, jumpStrength, jumpStrengthMultiplier, maxJumpStrength, gravityScale;

    bool isRunning, isGrounded;

    public bool canMove;

    public GameObject groundCheck;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        canMove = true;
    }

    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        isRunning = Input.GetButton("Sprint");
        Jump();
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
        isGrounded = groundCheck.GetComponent<GroundCheck>().onGround;
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - gravityScale);
    }

    //move player in direction pressed, if the run key is pressed, move by run speed
    void Move()
    {
        if (isRunning)
        {
            Run();
        }
        else
        {
            Walk();
        }
    }

    void Walk()
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

    void Run()
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
        if(isGrounded && Input.GetButton("Jump"))
        {
            jumpStrength += jumpStrengthMultiplier * Time.deltaTime;
            if(jumpStrength > maxJumpStrength)
            {
                jumpStrength = maxJumpStrength;
            }
        }
        if(isGrounded && Input.GetButtonUp("Jump"))
        {
            Debug.Log("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength + baseJumpHeight);
            jumpStrength = 0;
        }
    }
}
