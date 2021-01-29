using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEndPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("You have completed the gameee!!!");
        }
    }
}
