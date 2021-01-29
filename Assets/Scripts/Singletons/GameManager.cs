using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GenericSingletonClass<GameManager>
{

    public int axeQuantityPerPowerup = 5;
    public int maxLives = 3;
    private int _axeQuantity = 0;
    private int _coins = 0;
    private int _currentLives;
    void Start()
    {
        _currentLives = maxLives;
    }

    void Update()
    {
        
    }

    public void EnableAxeMode()
    {
        _axeQuantity += axeQuantityPerPowerup;
    }
    
    public void DisableAxeMode()
    {
        _axeQuantity = 0;
    }

    public int GetAxeQuantity()
    {
        return _axeQuantity;
    }

    public bool TryToThrowAxe()
    {
        if (_axeQuantity > 0)
        {
            _axeQuantity -= 1;
            return true;
        } else 
        {
            return false;
        }
    }

    public void AddCoin()
    {
        _coins += 1;
    }

    public int GetCoins()
    {
        return _coins;
    }

    public int GetCurrentLives()
    {
        return _currentLives;
    }

    public bool TryRespawnPlayer()
    {
        if (_currentLives > 0)
        {
            _currentLives -= 1;
            return true;
        }
        else
        {
            return false;
        }
    }


}
