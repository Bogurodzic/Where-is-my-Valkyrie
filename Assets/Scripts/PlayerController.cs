using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 2f;
    public bool isGrounded = false;

    private Animator _playerAnimator;

    private float _lastPlayerYPosition;
    void Start()
    {
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
        if (Input.GetKeyDown("space") && isGrounded==true)
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
        } else if (Input.GetAxis("Horizontal") == 0)
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
}
