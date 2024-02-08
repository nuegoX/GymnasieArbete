/*using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentSpawner : MonoBehaviour
{
    public GameObject firstAgentPrefab;  // Reference to your agent prefab
    public GameObject secondAgentPrefab;
    public GameObject thirdAgentPrefab;
    public Transform spawnPoint;   // The point where the agents will be spawned
    public int NumberSpawned;

    void Start()
    {
        StartCoroutine(SpawnAgents());
    }

    IEnumerator SpawnAgents()
    {
        yield return new WaitForSeconds(10f);  // Wait for 1 minute
        SpawnAgent();

        yield return new WaitForSeconds(15f);  // Wait for 4 minutes
        SpawnAgent();

        yield return new WaitForSeconds(20f);  // Wait for 4 more minutes (total 8 minutes)
        SpawnAgent();
    }

    void SpawnAgent()
    {
        NumberSpawned++;

        switch (NumberSpawned)
        {
            case 1:
                Instantiate(firstAgentPrefab, spawnPoint.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(secondAgentPrefab, spawnPoint.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(thirdAgentPrefab, spawnPoint.position, Quaternion.identity);
                break;
        }
    }
}
using System.Collections;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    public GameObject firstAgentPrefab;  // Reference to your first agent prefab
    public GameObject secondAgentPrefab; // Reference to your second agent prefab
    public GameObject thirdAgentPrefab;  // Reference to your third agent prefab
    public Transform spawnPoint;         // The point where the agents will be spawned
    public Transform[] waypoints;        // Define waypoints for all agents in the Inspector

    void Start()
    {
        StartCoroutine(SpawnAgents());
    }

    IEnumerator SpawnAgents()
    {
        // Spawn the first agent with the waypoints
        yield return new WaitForSeconds(5f);  // Wait for 5 seconds before spawning the next agent
        SpawnAgent(firstAgentPrefab, waypoints);

        yield return new WaitForSeconds(5f);  // Wait for 5 seconds before spawning the next agent

        // Spawn the second agent with the waypoints
        SpawnAgent(firstAgentPrefab, waypoints);

        yield return new WaitForSeconds(5f);  // Wait for 5 seconds before spawning the next agent

        // Spawn the third agent with the waypoints
        SpawnAgent(thirdAgentPrefab, waypoints);
    }

    void SpawnAgent(GameObject agentPrefab, Transform[] agentWaypoints)
    {
        GameObject agent = Instantiate(agentPrefab, spawnPoint.position, Quaternion.identity);

        // Get the KronNPC script from the spawned agent
        KronNPC npcScript = agent.GetComponent<KronNPC>();

        // Assign waypoints to the NPC
        npcScript.SetWaypoints(agentWaypoints);
    }
}*/
using System.Collections;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    public GameObject agentPrefab;      // Reference to your agent prefab
    public Transform spawnPoint;        // The point where the agents will be spawned
    public Transform[] commonWaypoints; // Waypoints shared by all agents

    void Start()
    {
        StartCoroutine(SpawnAgents());
    }

    IEnumerator SpawnAgents()
    {
        for (int i = 0; i < 3; i++) // Spawn 3 agents
        {
            GameObject agent = Instantiate(agentPrefab, spawnPoint.position, Quaternion.identity);

            // Set waypoints for the NPC at spawn
            KronNPC npcScript = agent.GetComponent<KronNPC>();

            if (npcScript != null)
            {
                npcScript.SetWaypoints(commonWaypoints);
            }
            else
            {
                Debug.LogError("SpawnAgents: KronNPC script not found on the spawned agent.");
            }

            yield return new WaitForSeconds(5f);  // Wait for 5 seconds between spawns
        }
    }
}


