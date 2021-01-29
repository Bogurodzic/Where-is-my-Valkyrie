using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public bool mustPatrol, mustSleep = true;
    public float AwakeRange = 5f;
    public bool turn, isGrounded = false;
    public bool isPatroling,isSleeping = false;
    public float movementSpeed = 200f;
    
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private float _speed = 0f;
    protected GameObject Player;
    float distanceToPlayer = 0f;
    public Collider2D bodyCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        _speed = movementSpeed;


        LoadSettings();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = transform.position.x - Player.transform.position.x;
        //Debug.Log(distanceToPlayer);


        if (distanceToPlayer < AwakeRange&&isSleeping)
        {
            AwakeEnemy();
            isSleeping = false;

        }
        if (isPatroling)
        {
            Patrol();
        }

        if (bodyCollider.IsTouching(bodyCollider))
        {
            Debug.Log("Body COlider cos zlapal");
        }

        rb.velocity = new Vector2(movementSpeed * Time.fixedDeltaTime, rb.velocity.y);


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
        if (isPatroling)
        {
            if (turn && isGrounded)
            {
                Turn();

            }
            
        }
    }

   public void Turn()
    {
        if (isPatroling&&!isSleeping)
        {
            isPatroling = false;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            movementSpeed *= -1;
            isPatroling = true;
            Debug.Log("Turning w patrolu");
        }
        else if(!isSleeping) {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            movementSpeed *= -1;
            Debug.Log("Turning bez patrolu");
        }

    }
    void SleepEnemy()
    {
        isSleeping = true;
        _speed = movementSpeed;
        movementSpeed = 0f;
        Debug.Log("Sleeping");
    }

    void AwakeEnemy()
    {

        
        movementSpeed = _speed;
        Debug.Log("Awaking");

    }
    void LoadSettings()
    {
        

        if (mustPatrol)
        {
            isPatroling = true;
        }
        if (mustSleep)
        {
            SleepEnemy();
        }
    }
    public void Hurt()
    {
        //Destroy(this.gameObject);
        Debug.Log("Enemy.Hurt");
    }

    void OnCollisionEnter2D(Collision2D bodyCollision)
    {
        if (bodyCollision.collider.tag == "Enemy")
        {
            
            Turn();

        }
        if (bodyCollider.IsTouchingLayers(groundLayer))
        {
            Turn();
        }
    }

}


