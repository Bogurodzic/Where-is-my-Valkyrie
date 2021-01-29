using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GenericSingletonClass<GameManager>
{

    public int axeQuantityPerPowerup = 5;
    private int _axeQuantity = 0;
    void Start()
    {
        
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


}
