using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeCollectible : Collectible
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void ExecuteCollectibleLogic(Collider2D collider)
    {
        collider.gameObject.GetComponent<PlayerController>().EnableAxeMode();  
        Collect();
    }
}
