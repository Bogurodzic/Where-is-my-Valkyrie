using System;
using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("Playing first level 1");
        _currentLevel = 1;
        SceneManager.LoadScene(levels[_currentLevel - 1]);
    }

    public void GoToNextLevel()
    {
        if (_currentLevel < _lastLevelNumber)
        {
            _currentLevel += 1;
            Debug.Log("Playing level " + _currentLevel);

            SceneManager.LoadScene(levels[_currentLevel - 1]);
        }
        else
        {
            Debug.Log("Gameover ");

            GoToGameOverScreen();
        }
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(levels[_currentLevel - 1]);
    }

    public void GoToGameOverScreen()
    {
        SceneManager.LoadScene(gameOver);
    }
    
}
