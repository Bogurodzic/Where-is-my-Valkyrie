using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReduced : EnemyMovement
{
    bool hittedOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Hurt()
    {
        if (hittedOnce)
        {
            Destroy(this.gameObject);
        }
        if (!hittedOnce)
        {
            m_Animator.Play("Base Layer.enemy2_reduced", 0, 0);
            hittedOnce = true;
        }
            

        while (!m_Animator.GetCurrentAnimatorStateInfo(0).IsName("enemy2_reduced"))
        {
            hittedOnce = false;
        }
    }
}
