using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public bool isPatroling, turn, isGrounded;
    public float movementSpeed = 5f;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        speed = movementSpeed;
        isPatroling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGrounded)
        {
            movementSpeed = 0f;
        }
        if (isGrounded)
        {
            movementSpeed = speed;
        }
        if (isPatroling)
        {
            Patrol();
        }
    }
    void FixedUpdate()
    {
        if (isPatroling)
        {
            turn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        }
    }
    void Patrol()
    {
        if (turn&&isGrounded)
        {
            Turn();
        }
        rb.velocity = new Vector2(movementSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Turn()
    {
                    isPatroling = false;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            movementSpeed *= -1;
            isPatroling = true;
        
    }
}
