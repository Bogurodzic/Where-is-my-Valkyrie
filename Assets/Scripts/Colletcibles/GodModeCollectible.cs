using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodModeCollectible : Collectible
{
    protected override void ExecuteCollectibleLogic(Collider2D collider)
    {
        Collect();
        collider.gameObject.GetComponent<PlayerController>().EnableGodMode();  
    }
}
