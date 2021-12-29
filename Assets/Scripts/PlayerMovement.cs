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

    public Animator anim;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        canMove = true;
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        isRunning = Input.GetButton("Sprint");
        Jump();
        AnimChecks();
        Flip();
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
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength + baseJumpHeight);
            jumpStrength = 0;
        }
    }
    //flips player sprite
    void Flip()
    {
        if(rb.velocity.x > 0)
        {
            this.transform.localScale = new Vector3(2f, 2f, 1f);
        }
        if (rb.velocity.x < 0)
        {
            this.transform.localScale = new Vector3(-2f, 2f, 1f);
        }
    }
    //updates animator values
    void AnimChecks()
    {
        if (groundCheck.GetComponent<GroundCheck>().onGround)
        {
            anim.SetBool("inAir", false);
        }
        else
        {
            anim.SetBool("inAir", true);
        }
        if (Input.GetButton("Sprint"))
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
        if (hInput != 0 && !Input.GetButton("Sprint"))
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }
    public void Upgrade(bool upgrade)
    {
        if (upgrade) anim.SetBool("PoweredUp", true);
        else if (!upgrade) anim.SetBool("PoweredUp", false);
    }
}
