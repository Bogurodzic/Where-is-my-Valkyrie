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

    void Update()
    {
        
    }
    
    public void PointerEnter()
    {   
        _animator.SetBool("IsHighlited", true);
    }
 
    public void PointerExit()
    {
        _animator.SetBool("IsHighlited", false);
    }
}
