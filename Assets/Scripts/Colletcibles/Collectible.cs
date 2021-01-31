using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    protected AudioSource _audio;
    protected SpriteRenderer _sprite;
    protected BoxCollider2D _boxCollider;
    protected bool _collected = false;
    protected void Start()
    {
        _audio = GetComponent<AudioSource>();
        _sprite = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    protected void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && !_collected)
        {
            _collected = true;
            _sprite.enabled = false;
            _boxCollider.enabled = false;
            _audio.Play();
            ExecuteCollectibleLogic(collider);
        }
    }

    protected virtual void ExecuteCollectibleLogic(Collider2D collider)
    {
        Collect();
    }

    protected virtual void Collect()
    {
        Invoke("DestroyCollectibleObject", 0.5f);
    }

    protected void DestroyCollectibleObject()
    {
        Destroy(gameObject);
    }
}
