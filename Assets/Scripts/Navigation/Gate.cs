using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gate : MonoBehaviour
{

    public GameObject spawnLocationOnReachingGate;
    public GameObject newGateToMoveTowards;
    
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<NavMeshAgent>())
        {
            if (spawnLocationOnReachingGate != null)
                SendEnemyToNextDimension(col.gameObject);
            else
                KillEnemyAndDamagePlayer(col.gameObject);
        }
    }

    public void SendEnemyToNextDimension(GameObject enemyGO)
    {
        NavMeshAgent agent = enemyGO.GetComponent<NavMeshAgent>();
        agent.Warp(spawnLocationOnReachingGate.transform.position);
        agent.SetDestination(newGateToMoveTowards.transform.position);
        if (enemyGO.GetComponent<enemy>().inHell)
            enemyGO.GetComponent<enemy>().inHell = false;
    }

    public void KillEnemyAndDamagePlayer(GameObject enemyGO)
    {
        FindObjectOfType<Player>().DecreaseHealth(enemyGO.GetComponent<enemy>().enemyDamage);
        FindObjectOfType<Spawner>().EnemyHasBeenKilled();
        Destroy(enemyGO);
    }

}
