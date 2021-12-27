using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float walkSpeed, maxWalkSpeed, runSpeed, maxRunSpeed;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    //move player in direction pressed, if the run key is pressed, move by run speed
    void Move()
    {
        if (Input.GetAxis("Horizontal") > 0 && Mathf.Abs(rb.velocity.x) <= maxWalkSpeed && !Input.GetButton("Sprint"))
        {
            rb.velocity = new Vector2(rb.velocity.x + walkSpeed, rb.velocity.y);
        }
        else if (Input.GetAxis("Horizontal") < 0 && Mathf.Abs(rb.velocity.x) <= maxWalkSpeed && !Input.GetButton("Sprint"))
        {
            rb.velocity = new Vector2(rb.velocity.x - walkSpeed, rb.velocity.y);
        }
        else if (Mathf.Abs(rb.velocity.x) > maxWalkSpeed && !Input.GetButton("Sprint"))
        {
            rb.velocity = new Vector2(maxWalkSpeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        }
        else if (Input.GetButton("Sprint"))
        {
            SprintMove();
        }
    }

    void SprintMove()
    {
        if (Input.GetAxis("Horizontal") > 0 && Mathf.Abs(rb.velocity.x) <= maxRunSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x + runSpeed, rb.velocity.y);
        }
        else if (Input.GetAxis("Horizontal") < 0 && Mathf.Abs(rb.velocity.x) <= maxRunSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x - runSpeed, rb.velocity.y);
        }
        else if (Mathf.Abs(rb.velocity.x) > maxRunSpeed)
        {
            rb.velocity = new Vector2(maxRunSpeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        }
    }

    //if player is on ground and presses the jump key, jump
    void Jump()
    {
        //jump script
    }
}
