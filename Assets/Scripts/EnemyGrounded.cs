using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrounded : Grounded
{
    // Start is called before the first frame update

    protected override void HandleCollisionWithGround(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Character.GetComponent<EnemyMovement>().isGrounded = true;
        }
        if (collision.collider.tag == "Enemy")
        {   
            Character.GetComponent<EnemyMovement>().Turn();
            Debug.Log("enemy na drodze");
        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            
            Character.GetComponent<EnemyMovement>().isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
