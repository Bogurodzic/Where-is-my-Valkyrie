using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public bool mustPatrol, mustSleep = false;
    public float AwakeRange = 5f;
    public bool turn, isGrounded = false;
    public bool isPatroling = false;
    public bool isSleeping = false;
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
        if (turn && isGrounded || isGrounded && bodyCollider.IsTouchingLayers(groundLayer))
        {
            Turn();
            Debug.Log("Turn chuju");
        }
        rb.velocity = new Vector2(movementSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

   public void Turn()
    {
        isPatroling = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        movementSpeed *= -1;
        isPatroling = true;

    }
    void SleepEnemy()
    {
        isSleeping = true;
        _speed = movementSpeed;
        movementSpeed = 0f;
    }

    void AwakeEnemy()
    {

        
        movementSpeed = _speed;

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
}

