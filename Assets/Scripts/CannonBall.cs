using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(waitForDelete());
    }
    private void FixedUpdate()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerDamageDetection>().CrabHit(this.gameObject);
        }
        Destroy(this.gameObject);
    }
    IEnumerator waitForDelete()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
