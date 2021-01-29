using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinQuantity : MonoBehaviour
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
        int coinQuantity = GameManager.Instance.GetCoins();
        string coinText = "";
        if (coinQuantity < 10)
        {
            coinText = "x0" + coinQuantity;
        }
        else
        {
            coinText = "x" + coinQuantity;
        }
        _text.text = coinText;
    }
}
