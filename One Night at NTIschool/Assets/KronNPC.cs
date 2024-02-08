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
        if (waypoints != null && waypoints.Length > 0 && waypointIndex < waypoints.Length)
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
    public void SetWaypoints(Transform[] newWaypoints)
    {
        waypointIndex = 0; // Reset waypoint index when assigning new waypoints
        waypoints = newWaypoints;
        UpdateDestination();
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

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (waypoints.Length > 0)
        {
            UpdateDestination();
        }
        else
        {
            Debug.LogError("KronNPC: No waypoints assigned.");
        }
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

    public void SetWaypoints(Transform[] newWaypoints)
    {
        waypointIndex = 0; // Reset waypoint index when assigning new waypoints
        waypoints = newWaypoints;
        if (waypoints.Length > 0)
        {
            UpdateDestination();
        }
        else
        {
            Debug.LogError("KronNPC: No waypoints assigned.");
        }
    }
}

