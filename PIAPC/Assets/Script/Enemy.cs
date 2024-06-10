using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target; 
    [SerializeField] private float minDistance; 
    [SerializeField] private float speed; 
    [SerializeField] Transform WayPoints;

    private bool isFollowing = false; 
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < minDistance)
        {
            isFollowing = true;
            agent.SetDestination(target.position);
        } else 
        {
            isFollowing = false;
        }

        if(transform.position != WayPoints.position && !isFollowing)
        {
            agent.SetDestination(WayPoints.position);
        }
    }
}
