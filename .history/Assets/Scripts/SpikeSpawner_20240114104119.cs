using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpikeSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] spikePrefab;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (true)
        {
            yield return wait;

            int rand = Random.Range(0, spikePrefab.Length);
            GameObject spikeToSpawn = spikePrefab[rand];

            GameObject newSpike = Instantiate(spikeToSpawn);

            StartCoroutine(DestroyAfterDelay(newSpike, 5f));
        }
    }

    private IEnumerator DestroyAfterDelay(GameObject spike, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (spike != null)
        {
            Destroy(spike);
        }
    }
}

