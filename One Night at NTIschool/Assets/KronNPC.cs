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
    public float waypointDistance = 1f;
    public float chaseDistance = 5f;
    public float loseSightDistance = 10f;
    public float resumeWaypointsDelay = 2f; // Adjust this value for the desired delay before resuming waypoints

    private bool isChasing = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerPosition());

        if (distanceToPlayer < chaseDistance)
        {
            // If player is near, chase the player
            agent.SetDestination(PlayerPosition());
            isChasing = true;
        }
        else if (isChasing)
        {
            // If the NPC was chasing but player is out of sight, wait for a delay, then go back to waypoints
            StartCoroutine(ResumeWaypointsAfterDelay());
        }
        else if (Vector3.Distance(transform.position, target) < waypointDistance)
        {
            // If reached the current waypoint, go to the next waypoint
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

    IEnumerator ResumeWaypointsAfterDelay()
    {
        yield return new WaitForSeconds(resumeWaypointsDelay);

        // Reset waypoint index to go back to following waypoints
        waypointIndex = 0;
        UpdateDestination();
        isChasing = false;
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
