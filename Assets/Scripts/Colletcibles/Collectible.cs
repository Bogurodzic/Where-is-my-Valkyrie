using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            ExecuteCollectibleLogic(collider);
        }
    }

    protected virtual void ExecuteCollectibleLogic(Collider2D collider)
    {
        Collect();
    }

    protected virtual void Collect()
    {
        Destroy(gameObject);
    }
}
