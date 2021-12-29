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
        spawnPoint = this.transform;
        spawnPoint.transform.localPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y + 0.8f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Used", true);
            if (canBeUsed)
            {
                Instantiate(powerUpItem, spawnPoint);
                canBeUsed = false;
            }
        }
    }
}
