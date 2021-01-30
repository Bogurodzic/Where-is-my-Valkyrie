﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeProjectile : MonoBehaviour
{
    public float projectileSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * projectileSpeed);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.gameObject.tag == "Player"))
            Destroy(this.gameObject);
    }
}
