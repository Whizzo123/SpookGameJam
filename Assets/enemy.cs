﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.AI;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float enemySpeed;

    public float enemyHealth;

    public int enemyDamage;

    public bool flying;

    public bool inHell;

    public GameObject hellSpawnLocation; 

    void Start()
    {
        GetComponent<NavMeshAgent>().speed = enemySpeed;
        flying = false;
        inHell = false;
    }

    public void setSpeed(float enemySpeedChange)
    {
        enemySpeed = enemySpeed + enemySpeedChange;
    }
   
    public void setHealth(float enemyHealthChange)
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
                //this is a reminder for joe to link up his nav mesh here.
                GetComponent<NavMeshAgent>().Warp(hellSpawnLocation.transform.position);
            }
        }
            
    }

    public void toggleFlying()
    {
        if (flying == false)
            flying = true;
        else
            flying = false;
    }
}
