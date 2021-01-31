﻿using System;
using System.Collections;
using System.Collections.Generic;
using SceneTransition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : GenericSingletonClass<StageManager>
{
    public String[] levels;
    public String mainMenu;
    public String gameOver;
    public String choosingValkyrie;
    public String endingScreen;

    public String prologText;
    public String epilogueText;
    public String levelText;
    
    private int _currentLevel = 1;
    private int _lastLevelNumber;
    
    public void Start()
    {
        _lastLevelNumber = levels.Length;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void GoToControls()
    {
        SceneTransitionSettings.NextTransitionScene = TransitionScene.Controls;
        LoadTransitionScene();
    }

    public void GoToFirstStage()
    {
       SceneTransitionSettings.NextTransitionScene = TransitionScene.Prologue;
        _currentLevel = 1; 
        LoadTransitionScene();
    }
    
    private void LoadTransitionScene()
    {
        SceneManager.LoadScene("MainMenu");
        SceneManager.LoadScene("MainMenu");
        SceneManager.LoadScene("MainMenu");

        SceneManager.LoadScene("TransitionScene");
    }
    

    public void GoToNextLevel()
    {
        if (_currentLevel < _lastLevelNumber)
        {
            _currentLevel += 1;
            HandleRestartingCurrentLevel();
        }
        else
        {
            LoadChoosingValkyrie();
        }
    }

    private void LoadChoosingValkyrie()
    {
        TrackManager.Instance.PlayChoosingValkyrie();
        SceneManager.LoadScene(choosingValkyrie);
    }

    public void HandleEndingGame()
    {
        SceneTransitionSettings.NextTransitionScene = TransitionScene.Epilogue;
        LoadTransitionScene();
    }

    public void LoadEndingScreen()
    {
        SceneManager.LoadScene(endingScreen);
        TrackManager.Instance.PlayEpilogueTheme();
    }
    

    public void HandleRestartingCurrentLevel()
    {
        SceneTransitionSettings.NextTransitionScene = TransitionScene.Level;
        LoadTransitionScene();
        Invoke("RestartCurrentLevel", 2.5f);
    }

    public void PlayLevel()
    {
        RestartCurrentLevel();
    }

    private void RestartCurrentLevel()
    {
        SceneManager.LoadScene(levels[_currentLevel - 1]);
    }

    public void GoToGameOverScreen()
    {
        SceneManager.LoadScene(gameOver);
    }

    public int GetCurrentLevel()
    {
        return _currentLevel;
    }
    
}
