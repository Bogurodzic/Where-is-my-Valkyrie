using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PointerEnter()
    {   
        _animator.SetBool("isHover", true);
    }
 
    public void PointerExit()
    {
        _animator.SetBool("isHover", false);
    }
}
