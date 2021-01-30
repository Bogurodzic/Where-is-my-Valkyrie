﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{


    public void QuitGame()
    {
        StageManager.Instance.GoToMenu();
    }

    public void Continue()
    {
        StageManager.Instance.RestartCurrentLevel();
    }
}
