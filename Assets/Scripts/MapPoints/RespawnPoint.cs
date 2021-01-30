using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public GameObject playerPrefab;

    public void Start()
    { 
        //Instantiate(playerPrefab, transform.position, playerPrefab.transform.rotation);
    }

    public void RespawnPlayerOnPoint(GameObject player)
    {
        player.transform.position = transform.position;
    }
}
