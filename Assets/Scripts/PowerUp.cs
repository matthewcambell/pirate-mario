using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Rigidbody2D rbp;

    public GameObject player;

    [SerializeField]
    float speed;

    void Start()
    {
        rbp = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
            rbp.velocity = new Vector2(speed, rbp.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        speed *= -1;
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerDamageDetection>().PowerUp();
            Destroy(this.gameObject);
        }
    }
}
