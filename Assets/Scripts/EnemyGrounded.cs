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
            //Character.GetComponent<EnemyMovement>().isGrounded = true;
            Debug.Log("Sciana na drodze");
            Character.GetComponent<EnemyMovement>().Turn();
            
        }
        if (collision.collider.tag == "Enemy")
        {
            Debug.Log("enemy na drodze");
            Character.GetComponent<EnemyMovement>().Turn();
            
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
