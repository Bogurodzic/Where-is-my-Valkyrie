using System;
using System.Collections;
using System.Collections.Generic;
using SceneTransition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionAnimationController : MonoBehaviour
{
    private Animator _animator;
    private bool _enabled = false;
    void Start()
    {
        Invoke("EnableSpace", 1f);
        LoadComponents();
        SelectProperTransitionAnimation();
        
    }

    void Update()
    {

        if (_enabled && Input.GetKeyUp(KeyCode.Space) && (SceneTransitionSettings.NextTransitionScene == TransitionScene.Prologue || SceneTransitionSettings.NextTransitionScene == TransitionScene.Epilogue || SceneTransitionSettings.NextTransitionScene == TransitionScene.Controls))
        {
            ProceedToNextScene();
        }
    }

    private void EnableSpace()
    {
        _enabled = true;
    }

    private void LoadComponents()
    {
        _animator = GetComponent<Animator>();
    }

    private void SelectProperTransitionAnimation()
    {
  
            if (SceneTransitionSettings.NextTransitionScene == TransitionScene.Controls)
            {
                ResetAnimationVariables();
                _animator.SetBool("isControls", true);
            } else if (SceneTransitionSettings.NextTransitionScene == TransitionScene.Prologue)
            {
                ResetAnimationVariables();
                _animator.SetBool("isPrologue", true);
            } else if (SceneTransitionSettings.NextTransitionScene == TransitionScene.Level)
            {
                ResetAnimationVariables();
                string levelName = "level" + StageManager.Instance.GetCurrentLevel();
                _animator.SetBool(levelName, true);
            } else if (SceneTransitionSettings.NextTransitionScene == TransitionScene.Epilogue)
            {
                ResetAnimationVariables();
                _animator.SetBool("isEpilogue", true);
            }          
        

    }

    private void ProceedToNextScene()
    {
        if (SceneTransitionSettings.NextTransitionScene == TransitionScene.Controls)
        {
            StageManager.Instance.GoToFirstStage();
        } else if (SceneTransitionSettings.NextTransitionScene == TransitionScene.Prologue)
        {
            StageManager.Instance.HandleRestartingCurrentLevel();
        } else if (SceneTransitionSettings.NextTransitionScene == TransitionScene.Level)
        {

        } else if (SceneTransitionSettings.NextTransitionScene == TransitionScene.Epilogue)
        {
            StageManager.Instance.LoadEndingScreen();
        }    
    }

    private void ResetAnimationVariables()
    {
        _animator.SetBool("isControls", false);
        _animator.SetBool("isPrologue", false);
        _animator.SetBool("isEpilogue", false);
        _animator.SetBool("level1", false);
        _animator.SetBool("level2", false);
        _animator.SetBool("level3", false);
    }
}
