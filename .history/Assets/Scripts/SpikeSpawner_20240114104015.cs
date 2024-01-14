using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ContinuousSpikeSpawner : MonoBehaviour
{
    public GameObject spikePrefab;
    public float minY = -5f;
    public float maxY = 5f;
    public float moveSpeed = 5f;
    public float spawnInterval = 2f;
    public float destroyDelay = 3f; // Time delay before destroying the spike clone

    void Start()
    {
        // Start the coroutine to spawn spikes continuously
        StartCoroutine(SpawnSpikesContinuously());
    }

    IEnumerator SpawnSpikesContinuously()
    {
        while (true) // Keep spawning indefinitely
        {
            // Instantiate a new spike
            GameObject spike = Instantiate(spikePrefab, transform.position, Quaternion.identity);

            // Set the spike's movement parameters
            spike.GetComponent<RandomSpikeMovement>().minY = minY;
            spike.GetComponent<RandomSpikeMovement>().maxY = maxY;
            spike.GetComponent<RandomSpikeMovement>().moveSpeed = moveSpeed;

            // Start a coroutine to destroy the spike clone after a delay
            StartCoroutine(DestroyAfterDelay(spike, destroyDelay));

            // Wait for the specified spawn interval before spawning the next spike
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator DestroyAfterDelay(GameObject spike, float delay)
    {
        yield return new WaitForSeconds(delay);
        // Check if the spike is still valid before destroying
        if (spike != null)
            Destroy(spike);
    }
}

