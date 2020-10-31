using UnityEngine;
using UnityEngine.AI;

public class Navigate : MonoBehaviour
{
    public GameObject heavenGateTargetPos;
    private NavMeshAgent agent;
    public GameObject hellGateTargetPos;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(heavenGateTargetPos.transform.position);
    }
}
