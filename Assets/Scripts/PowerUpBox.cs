using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBox : MonoBehaviour
{
    Animator anim;

    bool canBeUsed = true;

    public Transform spawnPoint;

    public GameObject powerUpItem;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    //spawns power up once when the player hits under the block
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Used", true);
            if (canBeUsed)
            {
                Instantiate(powerUpItem, spawnPoint.position, spawnPoint.rotation);
                canBeUsed = false;
            }
        }
    }
}
