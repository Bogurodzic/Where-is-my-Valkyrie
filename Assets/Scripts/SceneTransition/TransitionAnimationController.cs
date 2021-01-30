using System.Collections;
using System.Collections.Generic;
using SceneTransition;
using UnityEngine;

public class TransitionAnimationController : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        LoadComponents();
        SelectProperTransitionAnimation();
    }

    private void LoadComponents()
    {
        _animator = GetComponent<Animator>();
    }

    private void SelectProperTransitionAnimation()
    {
        if (SceneTransitionSettings.NextTransitionScene == TransitionScene.Prologue)
        {
            _animator.SetBool("isPrologue", true);
        }
    }
}
