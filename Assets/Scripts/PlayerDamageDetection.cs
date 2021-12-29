using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageDetection : MonoBehaviour
{
    int health = 1;

    [SerializeField]
    float hitPowerX, hitPowerY;

    GameObject player;

    bool canGetHit = true;

    private void Start()
    {
        player = this.gameObject;
    }
    public void CrabHit(GameObject crab)
    {
        if (canGetHit)
        {
            canGetHit = false;
            health -= 1;
            if (player.transform.position.x < crab.transform.position.x)
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(hitPowerX, hitPowerY);
            }
            else if (player.transform.position.x > crab.transform.position.x)
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(-hitPowerX, hitPowerY);
            }
            if (health <= 0)
            {
                Debug.Log("OOF");
            }
            player.GetComponent<PlayerMovement>().canMove = false;
            StartCoroutine(HitTimer());
        }
    }
    IEnumerator HitTimer()
    {
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<PlayerMovement>().canMove = true;
        canGetHit = true;
    }
}
