using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCollectible : Collectible
{
    protected override void ExecuteCollectibleLogic(Collider2D collider)
    {
        GameManager.Instance.AddLife();
        Collect();
    }
}
