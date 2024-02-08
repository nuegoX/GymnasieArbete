using System.Collections;
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
        yield return new WaitForSeconds(60f);  // Wait for 1 minute
        SpawnAgent();

        yield return new WaitForSeconds(180f);  // Wait for 4 minutes
        SpawnAgent();

        yield return new WaitForSeconds(240f);  // Wait for 4 more minutes (total 8 minutes)
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
