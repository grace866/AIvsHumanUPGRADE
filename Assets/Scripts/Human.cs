using UnityEngine;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;   // keep if you're doing 2D top-down
        agent.updateUpAxis = false;     // keep if you're doing 2D top-down
        agent.autoRepath = true;        // optional; default is true
    }

    void Update()
    {
    if (!target || !agent.isOnNavMesh) return;

    // Re-issue the goal when mesh changed (stale) or path got invalid/partial

        agent.ResetPath();
        agent.SetDestination(target.position);
    }

}
