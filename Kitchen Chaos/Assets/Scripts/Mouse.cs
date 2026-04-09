
using UnityEngine;
using UnityEngine.AI;

public class Mouse : BaseCounter
{
    private enum State
    {
        Wandering,
        Stealing,
        GettingChased,
    }
    private State state;
    [SerializeField] private Transform[] wanderLocations;
    private Transform target;
    [SerializeField] private NavMeshAgent agent;
    void Awake()
    {
        state = State.Wandering;
        LocateNewTarget();    
    }

    void Update()
    {
        switch (state)
        {
            case State.Wandering:
                if(agent.remainingDistance<=agent.stoppingDistance)
                {
                    LocateNewTarget();
                }
                break;
            case State.Stealing:
                break;
            case State.GettingChased:
                break;
        }
    }

    private void LocateNewTarget()
    {
        target = wanderLocations[UnityEngine.Random.Range(0,wanderLocations.Length)];
        agent.SetDestination(target.position);
    }
}
