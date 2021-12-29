using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabEnemy : MonoBehaviour
{
    Rigidbody2D rbc;

    public GameObject player;

    public Animator anim;

    public bool canMove = true;

    [SerializeField]
    float speed, playerBounceHeight;

    void Start()
    {
        rbc = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rbc.velocity = new Vector2(speed, rbc.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        speed *= -1;
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerDamageDetection>().CrabHit(this.gameObject);
        }
    }

    public void Smashed()
    {
        //Kills Crab
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, playerBounceHeight);
        anim.Play("DeadCrab");
        canMove = false;
        StartCoroutine(KillTimer());
    }
    IEnumerator KillTimer()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
