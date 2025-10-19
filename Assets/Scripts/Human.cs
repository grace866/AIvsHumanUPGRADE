using UnityEngine;

public class Human : MonoBehaviour
{
    // current code is using the NavMeshAgent to move the human to the target position, which is the computer
    [SerializeField] Transform target;

    UnityEngine.AI.NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }
}