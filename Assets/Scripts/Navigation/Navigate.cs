using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.WSA.Input;

public class Navigate : MonoBehaviour
{
    public GameObject targetPos;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(targetPos.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
