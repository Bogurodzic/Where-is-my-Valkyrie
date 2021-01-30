using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public bool mustPatrol, mustSleep = true;
    public bool rangedEnemy = false;    
    bool turn, isPatroling, isSleeping = false;
    public bool isGrounded=false;
    public float healthPoints = 1f;
    public float movementSpeed = 200f;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public GameObject Player;
    public Collider2D bodyCollider;
    private float _speed = 0f;
    public Animator m_Animator;
    public bool isFacingLeft, isFacingRight;



    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = GameManager.Instance.enemyMovementSpeed;
        Player = GameObject.Find("Player");
        LoadParameters();

    }

    // Update is called once per frame
    void Update()
    {
        handleFacing();

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


        }
        if (!Player)
        {
            Player = GameObject.Find("Player");
        }
        if (movementSpeed != 0)
        {
            if (isFacingLeft)
            {
                movementSpeed = GameManager.Instance.enemyMovementSpeed;
            }
            if (isFacingRight)
            {
                movementSpeed = GameManager.Instance.enemyMovementSpeed * -1;
            }
        }
        rb.velocity = new Vector2(movementSpeed * Time.fixedDeltaTime, rb.velocity.y);

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
        if (!isSleeping) 
        { 
        isSleeping = true;
        movementSpeed = 0f;
        }
    }

    void AwakeEnemy()
    {
        isSleeping = false;
        if (isFacingLeft)
        {
            movementSpeed = GameManager.Instance.enemyMovementSpeed;
        }
        if (isFacingRight)
        {
            movementSpeed = GameManager.Instance.enemyMovementSpeed * -1;
        }
        
    }
    void LoadParameters()
    {
        _speed = movementSpeed;
        m_Animator = gameObject.GetComponent<Animator>();
        if (mustPatrol)
        {
            isPatroling = true;
        }
        if (mustSleep)
        {
            SleepEnemy();
        }
    }
    public virtual void Hurt()
    {
        //bool _isReduced;
        if (healthPoints > 1)
        {
            if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("enemy2_reduced") )
            {
                Destroy(this.gameObject);
            }
   


                m_Animator.Play("Base Layer.enemy2_reduced", 0, 0);
                //_isReduced = true;
            //m_Animator.SetTrigger("got_hit");
            //m_Animator.SetBool("already_hit", true);

        }
        healthPoints = healthPoints - 1;
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
            float _distanceToPlayer = transform.position.x - Player.transform.position.x;
            if (_distanceToPlayer < GameManager.Instance.awakeRange && isSleeping)
            {
                AwakeEnemy();

            }
        }

    }
    public void handleFacing()
    {
        GameObject _front = gameObject.transform.GetChild(0).gameObject;
        GameObject _back = gameObject.transform.GetChild(1).gameObject;

            if (_front.transform.position.x > _back.transform.position.x)
            {
                isFacingRight = true;
                isFacingLeft = false;

            }
            else
            {
                isFacingRight = false;
                isFacingLeft = true;
            }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AxeProjectile") { 
            Hurt();
            Hurt();
            Hurt();
    }
    }

}





