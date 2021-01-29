using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 2f;
    public bool isGrounded = false;
    Rigidbody2D rb;

    private Animator _playerAnimator;

    private float _lastPlayerYPosition;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        LoadComponents();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        
    }
    void FixedUpdate()
    {
        HandleMovement();

    }

    private void LoadComponents()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    void Jump()
    {
        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        SwitchBetweenFallingAndJumping();
    }

    private void HandlePlayerOnGround()
    {
        _playerAnimator.SetBool("isJumping", false);
        _playerAnimator.SetBool("isFalling", false);
        _playerAnimator.SetBool("isInAir", false);
    }

    private void SwitchBetweenFallingAndJumping()
    {
        if (!isGrounded && transform.position.y > _lastPlayerYPosition)
        {
            _playerAnimator.SetBool("isJumping", true);
            _playerAnimator.SetBool("isFalling", false);
            _playerAnimator.SetBool("isInAir", true);        }
        else if (!isGrounded && transform.position.y < _lastPlayerYPosition)
        {
            _playerAnimator.SetBool("isJumping", false);
            _playerAnimator.SetBool("isFalling", true);
            _playerAnimator.SetBool("isInAir", true);        
        } else if (isGrounded)
        {
            HandlePlayerOnGround();
        }

        _lastPlayerYPosition = transform.position.y;
    }

    private void HandleMovement()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (PlayerIsFacingRight())
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (PlayerIsFacingLeft())
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * movementSpeed;
            _playerAnimator.SetFloat("Speed", 1);
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            _playerAnimator.SetFloat("Speed", 0);
        }

    }

    private bool PlayerIsFacingRight()
    {
      return Input.GetAxis("Horizontal") > 0;
    }

    private bool PlayerIsFacingLeft()
    {
        return Input.GetAxis("Horizontal") < 0;
    }

    public void Hurt()
    {
        Debug.Log("Player.Hurt()");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyMovement enemy = collision.collider.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                
                Debug.DrawLine(point.point, point.point + point.normal, Color.red, 10);
                if (point.normal.y >= 0.9f)
                {
                    Vector2 velocity = rb.velocity;
                    velocity.y = jumpForce;
                    rb.velocity = velocity;
                    enemy.Hurt();
                }
                else
                {
                    Hurt();
                }
            }
        }
    }
}
