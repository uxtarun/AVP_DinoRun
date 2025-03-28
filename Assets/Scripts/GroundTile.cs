using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField]
    private GroundSpawner groundSpawner;

    public GameObject[] obstaclePrefabs; // Array to hold multiple obstacle prefabs
    public float noObstacleChance = 0.3f; // Probability of no obstacle (e.g., 30%)

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacles();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnNewTile();
        Destroy(gameObject, 5); // Destroy the ground tile after 5 seconds
    }

    void SpawnObstacles()
    {
        // Decide whether to spawn an obstacle or not
        if (Random.Range(0f, 1f) < noObstacleChance)
        {
            // No obstacle will spawn
            return;
        }

        // Choose a random spawn position
        int obstacleSpawnIndex = Random.Range(2, 5); // Assuming valid child indices are 2 to 4
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Choose a random obstacle from the array
        if (obstaclePrefabs.Length > 0)
        {
            int randomObstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            GameObject selectedObstacle = obstaclePrefabs[randomObstacleIndex];

            // Spawn the selected obstacle at the chosen spawn position
            Instantiate(selectedObstacle, spawnPoint.position, Quaternion.identity, transform);
        }
        else
        {
            Debug.LogWarning("No obstacle prefabs assigned to GroundTile.");
        }
    }
}
