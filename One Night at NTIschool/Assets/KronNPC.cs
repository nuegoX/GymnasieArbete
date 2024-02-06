/*using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class KronNPC : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }
    void UpdateDestination ()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }
    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}*/
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class KronNPC : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    public string playerTag = "Player";
    public float sightRange = 10f;
    public float fieldOfView = 60f; // Adjust this value for the desired field of view

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    private void Update()
    {
        if (CanSeePlayer())
        {
            target = PlayerPosition();
            agent.SetDestination(target);
        }
        else if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    bool CanSeePlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);
            float distance = direction.magnitude;

            if (angle < fieldOfView * 0.5f && distance < sightRange)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, direction.normalized, out hit, sightRange))
                {
                    if (hit.collider.CompareTag(playerTag))
                    {
                        Debug.DrawRay(transform.position, direction.normalized * sightRange, Color.green);
                        return true;
                    }
                }
            }
        }

        return false;
    }

    Vector3 PlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            return player.transform.position;
        }
        return Vector3.zero; // Return some default position if player not found
    }
}
