using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageDetection : MonoBehaviour
{
    int health = 1;

    [SerializeField]
    float hitPowerX, hitPowerY;

    GameObject player;

    private void Start()
    {
        player = this.gameObject;
    }
    public void crabHit(GameObject crab)
    {
        if(player.transform.position.x < crab.transform.position.x)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(hitPowerX, hitPowerY);
        }
        if (player.transform.position.x > crab.transform.position.x)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(-hitPowerX, hitPowerY);
        }
        if(health <= 0)
        {
            Debug.Log("OOF");
        }
    }
}
