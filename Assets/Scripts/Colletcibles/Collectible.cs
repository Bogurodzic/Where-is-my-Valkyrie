using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           // Debug.Log("TRIGGERED");
            Collect();
            other.gameObject.GetComponent<PlayerController>().EnableAxeMode();
        }
    }

    protected void Collect()
    {
        Destroy(gameObject);
    }
}
