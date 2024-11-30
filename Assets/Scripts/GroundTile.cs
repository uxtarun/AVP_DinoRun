
using UnityEngine;

public class GroundTile : MonoBehaviour
{

    [SerializeField]
    private GroundSpawner groundSpawner;
    public GameObject[] obstaclePrefabs; // Array to hold multiple obstacle prefabs
    public float noObstacleChance = 0.3f; // Probability of no obstacle (e.g., 30%)



    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacles();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnNewTile();
        Destroy(gameObject, 3);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;

    void SpawnObstacles()
    {
        // Decide whether to spawn an obstacle or not
        float noObstacleChance = 0.3f; // 30% chance of no obstacle
        if (Random.Range(0f, 1f) < noObstacleChance)
        {
            // No obstacle will spawn
            return;
        }

        // Choose a random spawn position
        int obstacleSpawnIndex = Random.Range(2, 5); // Assuming valid child indices are 2 to 4
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstacle at the selected position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}
