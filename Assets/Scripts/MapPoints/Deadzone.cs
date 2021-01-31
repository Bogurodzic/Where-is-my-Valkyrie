using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{

    private BoxCollider2D _box;
    void Start()
    {
        LoadComponents();
    }

    private void LoadComponents()
    {
        _box = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().Hurt();
        }
    }
}
