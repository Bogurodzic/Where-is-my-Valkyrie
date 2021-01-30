using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public EnemyMovement enemyMovement;
    public GameObject fireballPrefab;
    private bool playerInRange = false;
    private float _lastEnemyXPosition;
    GameObject Player;
    Vector3 playerPos;


    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = this.GetComponent<EnemyMovement>();
        enemyMovement.movementSpeed = 0f;
        StartCoroutine(attack());
    }

    IEnumerator attack()
    {
        while (!enemyMovement.toKill)
        {
            if (!enemyMovement.isSleeping) { 
            if (playerInRange)
            {
                if (enemyMovement.m_Animator)
                {
                    enemyMovement.m_Animator.SetBool("isCasting", true);
                    handleCastFireball();
                }  
            }
            if (!playerInRange)
            {
                if (enemyMovement.m_Animator)
                {
                    enemyMovement.m_Animator.SetBool("isCasting", false);
                    if (enemyMovement.movementSpeed == 0)
                    {
                        FacePlayer();
                        if (enemyMovement.isFacingLeft)
                        {
                            enemyMovement.movementSpeed = GameManager.Instance.enemyMovementSpeed;
                        }
                        if (enemyMovement.isFacingRight)
                        {
                            enemyMovement.movementSpeed = GameManager.Instance.enemyMovementSpeed * -1;
                        }
                    }
                }
            }
            }

            yield return new WaitForSeconds(GameManager.Instance.timeBetweenAttack);
            
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (!enemyMovement.toKill) 
        { 
            SwitchBetweenAnimations();
            CheckPlayerInRange();
        }
    }
    void FacePlayer()
    {
        GameObject _front = gameObject.transform.GetChild(0).gameObject;
        GameObject _back = gameObject.transform.GetChild(1).gameObject;
        
        if (transform.position.x > playerPos.x)
        {
            if (_front.transform.position.x > _back.transform.position.x)
            {
                enemyMovement.Turn();
                
            }
        }
        if (transform.position.x < playerPos.x)
        {
            if (_front.transform.position.x < _back.transform.position.x)
            {
                enemyMovement.Turn();
                
            }
        }

        enemyMovement.handleFacing();
    }
    void handleCastFireball()
    {
        FacePlayer();
        enemyMovement.movementSpeed = 0f;
        enemyMovement.m_Animator.Play("Base Layer.enemy3_charge",0,0);
        

        
        GameObject a = Instantiate(fireballPrefab, transform.position, transform.localRotation);
        if (enemyMovement.isFacingRight)
        {
            a.GetComponent<FireballProjectile>().direction = Vector3.right;
        }
        if (enemyMovement.isFacingLeft)
        {
            a.GetComponent<FireballProjectile>().direction = Vector3.left;
        }


    }
    void CheckPlayerInRange()
    {
        PlayerPosition();
        float _distanceToPlayer = Mathf.Abs(transform.position.x - playerPos.x);

        if (_distanceToPlayer < GameManager.Instance.enemyAttackRange)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
    }
    void PlayerPosition()
    {
        if (Player)
        {
            playerPos = Player.transform.position;
        }
        if (!Player)
        {
            Player = GameObject.Find("Player");
        }
    }
    void SwitchBetweenAnimations()
    {
        
        if (_lastEnemyXPosition == transform.position.x)
        {
            enemyMovement.m_Animator.SetBool("isMoving", false);
        }
        else
        {
            enemyMovement.m_Animator.SetBool("isMoving", true);
        }
        _lastEnemyXPosition = transform.position.x;
    }
       
}
