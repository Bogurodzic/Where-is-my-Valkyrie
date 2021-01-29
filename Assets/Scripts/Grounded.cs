using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Grounded : MonoBehaviour
{
   
   protected GameObject Character;

    protected void Start()
    {
        Character = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollisionWithGround(collision);
    }
   protected virtual void HandleCollisionWithGround(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            
            Character.GetComponent<PlayerController>().isGrounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground") 
        {
            
            Character.GetComponent<PlayerController>().isGrounded = false;
        }
    }
}
