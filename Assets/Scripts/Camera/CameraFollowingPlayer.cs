using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingPlayer : MonoBehaviour
{
    public Vector3 offset;
    public GameObject player;

    void Update()
    {
        if (player)
        {
            transform.position = new Vector3 (player.transform.position.x + offset.x, player.transform.position.y + offset.y, offset.z);
        }
        else
        {
            player = TryToLoadPlayerGameObject();
        }
    }


    private GameObject TryToLoadPlayerGameObject()
    {
        return GameObject.Find("Player");
    }
}
