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
            ResetAnimationVariables();
            _animator.SetBool("isPrologue", true);
        }

        if (SceneTransitionSettings.NextTransitionScene == TransitionScene.Level)
        {
            ResetAnimationVariables();
            string levelName = "level" + StageManager.Instance.GetCurrentLevel();
            _animator.SetBool(levelName, true);
        }

        if (SceneTransitionSettings.NextTransitionScene == TransitionScene.Epilogue)
        {
            ResetAnimationVariables();
            _animator.SetBool("isEpilogue", true);
        }
    }

    private void ResetAnimationVariables()
    {
        _animator.SetBool("isPrologue", false);
        _animator.SetBool("isEpilogue", false);
        _animator.SetBool("level1", false);
        _animator.SetBool("level2", false);
        _animator.SetBool("level3", false);
    }
}
