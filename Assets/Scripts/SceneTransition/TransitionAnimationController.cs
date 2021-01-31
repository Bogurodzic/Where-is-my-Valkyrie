using System;
using System.Collections;
using System.Collections.Generic;
using SceneTransition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionAnimationController : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        LoadComponents();
        SelectProperTransitionAnimation();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (SceneTransitionSettings.NextTransitionScene == TransitionScene.Prologue || SceneTransitionSettings.NextTransitionScene == TransitionScene.Epilogue))
        {
            ProceedToNextScene();
        }
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

    private void ProceedToNextScene()
    {
        if (SceneTransitionSettings.NextTransitionScene == TransitionScene.Prologue)
        {
            StageManager.Instance.HandleRestartingCurrentLevel();
        }

        if (SceneTransitionSettings.NextTransitionScene == TransitionScene.Level)
        {

        }

        if (SceneTransitionSettings.NextTransitionScene == TransitionScene.Epilogue)
        {
            StageManager.Instance.LoadEndingScreen();
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
