using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GenericSingletonClass<GameManager>
{

    public int axeQuantityPerPowerup = 5;
    public int maxLives = 3;
    public int godModeTime = 10;

    public float enemyAttackRange = 9f;
    public float awakeRange = 10f;
    public float enemyMovementSpeed = -200f;
    public float fireBallProjectileSpeed = 1f;


    private int _axeQuantity = 0;
    private int _coins = 0;
    private int _currentLives;
    private float _timer;
    private int _currentGodModeTime = 0;
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

    public void AddLife()
    {
        _currentLives += 1;
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

    public void SetTimer(float time)
    {
        _timer = time;
    }

    public float GetTimer()
    {
        return _timer;
    }

    public void EnableGodMode()
    {
        Debug.Log("ENABLING GOD MODE");
        _currentGodModeTime = godModeTime;
        StartCoroutine(GodModeCountdown());
    }

    public int GetRemainingGodModeTime()
    {
        return _currentGodModeTime;
    }
    
    protected IEnumerator GodModeCountdown()
    {
        for (int i = 0; i < godModeTime; i++)
        {   
            _currentGodModeTime -= 1;
            yield return new WaitForSeconds(1);
        }
    }

    
}
