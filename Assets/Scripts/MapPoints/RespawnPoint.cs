using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public void RespawnPlayerOnPoint(GameObject player)
    {
        player.transform.position = transform.position;
    }
}
