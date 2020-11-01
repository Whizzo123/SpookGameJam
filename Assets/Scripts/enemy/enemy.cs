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

    public float creditsOnDeath;

    public bool haveHolyWaterModifierApplied;

    private Animator animator;

    public GameObject impactEffect;

    void Start()
    {
        GetComponent<NavMeshAgent>().speed = enemySpeed;
        flying = false;
        inHell = false;
        haveHolyWaterModifierApplied = false;
        originalEnemyHealth = enemyHealth;
        animator = GetComponent<Animator>();
    }

    public void SetSpeed(float enemySpeedChange)
    {
        enemySpeed = enemySpeed + enemySpeedChange;
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|Dying") && animator.GetBool("IsDead") == true)
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
            if(info.normalizedTime > 1f)
            {
                Destroy(this.gameObject);
            }
        }

    }
   
    public void SetHealth(float enemyHealthChange)
    {
        if(haveHolyWaterModifierApplied)
        {
            enemyHealthChange *= 2;
        }
        enemyHealth = enemyHealth + enemyHealthChange;
        if(enemyHealth <= 0)
        {
            if (inHell == true) 
            {
                GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(effectIns, 2);

                FindObjectOfType<Spawner>().EnemyHasBeenKilled();
                animator.SetBool("IsDead", true);
                GetComponent<NavMeshAgent>().SetDestination(this.transform.position);
                
            }
            else
            {
                GetComponent<NavMeshAgent>().Warp(hellSpawnLocation.transform.position);
                GetComponent<NavMeshAgent>().SetDestination(GetComponent<Navigate>().hellGateTargetPos.transform.position);
                enemyHealth = originalEnemyHealth;
                FindObjectOfType<BuildManager>().PlayerMoney += creditsOnDeath;
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
