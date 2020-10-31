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
            NavMeshAgent agent = col.gameObject.GetComponent<NavMeshAgent>();
            agent.Warp(spawnLocationOnReachingGate.transform.position);
            agent.SetDestination(newGateToMoveTowards.transform.position);
        }
    }

}
