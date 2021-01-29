using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : Collectible
{
    protected override void ExecuteCollectibleLogic(Collider2D collider)
    {
        GameManager.Instance.AddCoin();
        Collect();
    }
}
