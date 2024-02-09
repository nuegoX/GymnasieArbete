/*using System.Collections;
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
    public float chaseRaycastDistance = 10f;
    public LayerMask raycastLayer;
    public float resumeWaypointsDelay = 2f;

    private bool isChasing = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    private void Update()
    {
        if (CanSeePlayer())
        {
            // If player is in sight, chase the player
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

    bool CanSeePlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            RaycastHit hit;

            // Perform a raycast to check if the player is in sight
            if (Physics.Raycast(transform.position, direction.normalized, out hit, chaseRaycastDistance, raycastLayer))
            {
                if (hit.collider.CompareTag(playerTag))
                {
                    Debug.DrawRay(transform.position, direction.normalized * chaseRaycastDistance, Color.green);
                    return true;
                }
            }
        }

        return false;
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
    public float chaseRaycastDistance = 10f;
    public LayerMask raycastLayer;
    public float resumeWaypointsDelay = 2f;

    private bool isChasing = false;

    public float wakeupTimeMin = 30f;  // Minimum time to wait before waking up
    public float wakeupTimeMax = 480f; // Maximum time to wait before waking up

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(WaitAndWakeUp());
    }

    private void Update()
    {
        if (!isChasing)
        {
            return; // Don't execute normal behavior if not chasing yet
        }

        if (CanSeePlayer())
        {
            // If player is in sight, chase the player
            agent.SetDestination(PlayerPosition());
            isChasing = true;
        }
        else if (Vector3.Distance(transform.position, target) < waypointDistance)
        {
            // If reached the current waypoint, go to the next waypoint
            IterateWaypointIndex();
            UpdateDestination();
            StartCoroutine(WaitToResumeWaypoints());
        }
    }

    void UpdateDestination()
    {
        if (waypointIndex < waypoints.Length)
        {
            target = waypoints[waypointIndex].position;
            agent.SetDestination(target);
        }
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
            RaycastHit hit;

            // Perform a raycast to check if the player is in sight
            if (Physics.Raycast(transform.position, direction.normalized, out hit, chaseRaycastDistance, raycastLayer))
            {
                if (hit.collider.CompareTag(playerTag))
                {
                    Debug.DrawRay(transform.position, direction.normalized * chaseRaycastDistance, Color.green);
                    return true;
                }
            }
        }

        return false;
    }

    IEnumerator WaitAndWakeUp()
    {
        float wakeupTime = Random.Range(wakeupTimeMin, wakeupTimeMax);
        yield return new WaitForSeconds(wakeupTime);

        // Start chasing waypoints
        isChasing = true;
        UpdateDestination();
    }

    IEnumerator WaitToResumeWaypoints()
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
