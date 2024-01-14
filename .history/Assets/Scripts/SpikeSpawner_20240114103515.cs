using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] spikePrefab;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    private IEnumerator Spawner() {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while(true) {
            yield return wait;
            int rand = Random.Range(0, spikePrefab.Length -1);
            GameObject spikeToSpawn = spikePrefab[rand];
            
            Instantiate(spikeToSpawn);
            Destroy(spikeToSpawn, 3.0f);
        }
    }
}

