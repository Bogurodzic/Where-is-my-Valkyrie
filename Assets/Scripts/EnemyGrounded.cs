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
