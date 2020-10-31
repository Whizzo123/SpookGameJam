using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.AI;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float enemySpeed;

    public float enemyHealth;

    private float originalEnemyHealth;

    public int enemyDamage;

    public bool flying;

    public bool inHell;

    public GameObject hellSpawnLocation; 

    void Start()
    {
        GetComponent<NavMeshAgent>().speed = enemySpeed;
        flying = false;
        inHell = false;
        originalEnemyHealth = enemyHealth;
    }

    public void SetSpeed(float enemySpeedChange)
    {
        enemySpeed = enemySpeed + enemySpeedChange;
    }
   
    public void SetHealth(float enemyHealthChange)
    {
        enemyHealth = enemyHealth + enemyHealthChange;
        if(enemyHealth <= 0)
        {
            if (inHell == true) 
            {
                FindObjectOfType<Spawner>().EnemyHasBeenKilled();
                Destroy(this.gameObject);
            }
            else
            {
                GetComponent<NavMeshAgent>().Warp(hellSpawnLocation.transform.position);
                GetComponent<NavMeshAgent>().SetDestination(GetComponent<Navigate>().hellGateTargetPos.transform.position);
                enemyHealth = originalEnemyHealth;
                inHell = true;
            }
        }
            
    }

    public void ToggleFlying()
    {
        if (flying == false)
            flying = true;
        else
            flying = false;
    }
}
