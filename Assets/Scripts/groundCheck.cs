using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public bool onGround = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checks if on ground
        if(collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //checks if on ground
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }
}
