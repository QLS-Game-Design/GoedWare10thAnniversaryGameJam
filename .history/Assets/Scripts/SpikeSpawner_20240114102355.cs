using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] spikePrefab;

    void Start()
    {
        StartCoroutine
    }

    // Update is called once per frame
    private IEnumerator Spawner() {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while(true) {
            yield return wait;
        }
    }
}

