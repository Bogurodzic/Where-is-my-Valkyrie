using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public bool mustPatrol, mustSleep = true;
    public float AwakeRange = 5f;
    bool turn, isPatroling, isSleeping = false;
    public bool isGrounded=false;
    public float healthPoints = 1f;
    public float movementSpeed = 200f;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    protected GameObject Player;
    public Collider2D bodyCollider;
    private float _speed = 0f;
    Animator m_Animator;



    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        Player = GameObject.Find("Player");
        


        LoadParameters();

    }

    // Update is called once per frame
    void Update()
    {
        if (isSleeping)
        {
            CheckForAwake();
        }

        if (!isSleeping) 
        { 
            if (isPatroling)
            {
                Patrol();
            }

            rb.velocity = new Vector2(movementSpeed * Time.fixedDeltaTime, rb.velocity.y);
        }

  


    }
    void FixedUpdate()
    {
        if (!isSleeping)
        {
            if (isPatroling)
            {
                turn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
            }
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
            
        }
        else if(!isSleeping) {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            movementSpeed *= -1;
            
        }

    }
    void SleepEnemy()
    {
        isSleeping = true;
        _speed = movementSpeed;
        movementSpeed = 0f;
        ;
    }

    void AwakeEnemy()
    {
        movementSpeed = _speed;
        isSleeping = false;
    }
    void LoadParameters()
    {
        _speed = movementSpeed;
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
        if (healthPoints > 2)
        {
           

            m_Animator.SetTrigger("got_hit");
            m_Animator.SetBool("already_hit", true);
            
        }
        healthPoints = healthPoints - 1;
        //Debug.Log(healthPoints);
        if (healthPoints == 0)
            { 
            Destroy(this.gameObject);
            }
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
    void CheckForAwake()
    {
        if (Player)
        {
            float distanceToPlayer = transform.position.x - Player.transform.position.x;
            if (distanceToPlayer < AwakeRange && isSleeping)
            {
                AwakeEnemy();

            }
        }

    }


}


