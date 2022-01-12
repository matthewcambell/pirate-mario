using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    GameObject ball;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(ball, this.gameObject.transform.position + new Vector3(-1.5f, 0f, 0f), this.gameObject.transform.rotation);
        }
    }
}
