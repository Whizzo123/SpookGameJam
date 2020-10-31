using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float enemySpeed ;

    public float enemyHealth ;

    public bool flying = false;

    public bool inHell = false; 

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
                Destroy(this.gameObject);
            }
            else
            {
                //this is a reminder for joe to link up his nav mesh here.
            }
        }
            
    }

    public void toggleFlying()
    {
        if (flying = false)
            flying = true;
        else
            flying = false;
    }
}
