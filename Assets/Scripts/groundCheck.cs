using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool onGround = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checks if on ground
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("PowerUpBox"))
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //checks if on ground
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("PowerUpBox"))
        {
            onGround = false;
        }
    }
}
