using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesQuantity : MonoBehaviour
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
        _text.text = "x" + GameManager.Instance.GetCurrentLives();
    }
}
