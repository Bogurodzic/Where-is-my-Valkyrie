using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
   
{
    public Vector3 direction;
    void Start()
    {
        //this.gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    void Update()
    {  if (direction == Vector3.right)
            this.gameObject.transform.localScale = new Vector3(-5, 5, 5);
        transform.Translate(direction * Time.deltaTime * GameManager.Instance.fireBallProjectileSpeed);
    }
     void OnTriggerEnter2D(Collider2D collision)
        {
            if (!(collision.gameObject.tag == "Enemy"))
            Destroy(this.gameObject);
        }
 }


