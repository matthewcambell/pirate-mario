using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabHitDetector : MonoBehaviour
{
     CrabEnemy crabEnemy;

    private void Start()
    {
        //gets the Crab Enemy Script from the parent of this object
        crabEnemy = this.gameObject.GetComponentInParent<CrabEnemy>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            crabEnemy.Smashed();
        }
    }
}
