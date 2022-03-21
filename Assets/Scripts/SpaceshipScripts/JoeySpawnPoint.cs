using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoeySpawnPoint : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;
    public float spawnXLimit = 16f;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        float random = Random.Range(-spawnXLimit, spawnXLimit);
        Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
        Instantiate(meteorPrefab, spawnPos, Quaternion.identity);

        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
