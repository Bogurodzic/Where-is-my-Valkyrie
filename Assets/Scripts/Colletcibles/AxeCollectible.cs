using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeCollectible : Collectible
{
    protected override void ExecuteCollectibleLogic(Collider2D collider)
    {
        collider.gameObject.GetComponent<PlayerController>().EnableAxeMode();  
        Collect();
    }
}
