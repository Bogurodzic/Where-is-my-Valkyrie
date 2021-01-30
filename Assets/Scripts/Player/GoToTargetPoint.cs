using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTargetPoint : MonoBehaviour
{
    public bool goToTargetPointEnabled = false;
    public float movementSpeed = 3f;
    private GameObject _targetPoint;
    private Animator _animator;
    void Start()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        _targetPoint = GameObject.Find("PlayerTargetPoint");
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (goToTargetPointEnabled && _targetPoint.transform.position.x > transform.position.x)
        {
            transform.position += Vector3.right * Time.deltaTime * movementSpeed;
            _animator.SetFloat("Speed", 1);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }
    }
}
