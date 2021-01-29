using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text _text;
    void Start()
    {
        LoadComponents();
    }

    private void LoadComponents()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        float timePassed = CalculatePassedTime();
        SetGameTimer(timePassed);
        UpdateTimerText();
    }
    
    private float CalculatePassedTime()
    {
        return GameManager.Instance.GetTimer() + Time.deltaTime;
    }

    private void SetGameTimer(float time)
    {
        GameManager.Instance.SetTimer(time);
    }

    private void UpdateTimerText()
    {
        _text.text = string.Format("{0, 3:000}", GameManager.Instance.GetTimer());
    }
}


