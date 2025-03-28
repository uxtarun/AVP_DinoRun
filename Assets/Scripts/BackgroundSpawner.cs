using UnityEngine;
using System.Collections; // Required for using IEnumerator and Coroutines

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject[] backgroundPrefabs;  // Array of background prefabs to spawn
    public Vector3 spawnAreaMin = new Vector3(-70f, -0.52f, 122f);  // Minimum spawn position in the area with Y fixed
    public Vector3 spawnAreaMax = new Vector3(-12f, -0.52f, 250f);  // Maximum spawn position in the area with Y fixed
    public float spawnInterval = 1.5f;  // Time interval to spawn a new background element

    private void Start()
    {
        // Start spawning background elements at the specified interval
        InvokeRepeating("SpawnBackground", 0f, spawnInterval);
    }

    private void SpawnBackground()
    {
        // Randomly choose a prefab from the backgroundPrefabs array
        int randomIndex = Random.Range(0, backgroundPrefabs.Length);
        GameObject backgroundPrefab = backgroundPrefabs[randomIndex];

        // Generate a random spawn position within the specified spawn area
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);

        // Set the Y position to be constant at -0.52f
        Vector3 spawnPos = new Vector3(randomX, 0f, randomZ);

        // Instantiate a new background element at the randomly generated spawn position
        GameObject newBackground = Instantiate(backgroundPrefab, spawnPos, Quaternion.identity);

        // Start moving the background, but don't destroy it
        StartCoroutine(MoveBackground(newBackground));
    }

    private IEnumerator MoveBackground(GameObject background)
    {
        // Move the background element along the Z-axis (negative direction)
        while (background.transform.position.z > spawnAreaMax.z)
        {
            background.transform.Translate(Vector3.back * SpeedManager.Instance.GetCurrentBackgroundSpeed() * Time.deltaTime);
            yield return null;  // Wait until the next frame to continue the loop
        }
    }
}
