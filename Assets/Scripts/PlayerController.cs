using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 2f;
    public bool isGrounded = false;

    private Animator _playerAnimator;
    // Start is called before the first frame update
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
        if (isGrounded)
        {
            _playerAnimator.SetBool("isJumping", false);
        } else
        {
            _playerAnimator.SetBool("isJumping", true);
        }
    }

    private void HandleMovement()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * movementSpeed;
            _playerAnimator.SetFloat("Speed", 1);
        } else if (Input.GetAxis("Horizontal") == 0)
        {
            _playerAnimator.SetFloat("Speed", 0);
        }

    }
}
