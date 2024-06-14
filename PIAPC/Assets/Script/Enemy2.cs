using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] Transform[] WayPoints;
    [SerializeField] private int currentWaypoint;

    NavMeshAgent agent;
    [SerializeField] private bool isWaiting;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        isWaiting = false;
        agent.SetDestination(WayPoints[currentWaypoint].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaiting && agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(time);
        currentWaypoint++;
        if (currentWaypoint == WayPoints.Length)
        {
            currentWaypoint = 0;
        }
        agent.SetDestination(WayPoints[currentWaypoint].position);
        isWaiting = false;
    }
}
