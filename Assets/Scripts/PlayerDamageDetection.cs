using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if(health == 1) player.GetComponent<PlayerMovement>().Upgrade(false);

            player.GetComponent<PlayerMovement>().canMove = false;
            StartCoroutine(HitTimer());
        }
    }
    public void PowerUp()
    {
        health = 2;
        player.GetComponent<PlayerMovement>().Upgrade(true);
    }
    IEnumerator HitTimer()
    {
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<PlayerMovement>().canMove = true;
        canGetHit = true;
    }
}
