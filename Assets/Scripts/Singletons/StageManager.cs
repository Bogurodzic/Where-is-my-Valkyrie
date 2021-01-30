using System;
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

    public void GoToFirstStage()
    {
        SceneTransitionSettings.NextTransitionScene = TransitionScene.Prologue;
        
        Debug.Log("Playing first level 1");
        _currentLevel = 1;
        LoadTransitionScene();
        Invoke("HandleRestartingCurrentLevel", 6);
    }
    
    private void LoadTransitionScene()
    {
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
            HandleEndingGame();
        }
    }

    private void HandleEndingGame()
    {
        SceneTransitionSettings.NextTransitionScene = TransitionScene.Epilogue;
        LoadTransitionScene();
    }

    public void HandleRestartingCurrentLevel()
    {
        SceneTransitionSettings.NextTransitionScene = TransitionScene.Level;
        LoadTransitionScene();
        Invoke("RestartCurrentLevel", 3.5f);
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
