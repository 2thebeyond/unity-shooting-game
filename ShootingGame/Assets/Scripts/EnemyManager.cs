using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime;
    float minTime = 1;
    float maxTime = 5;
    public float spawnTime = 1;
    public GameObject enemyPrefab;

    void Start()
    {
        spawnTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= spawnTime)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = transform.position;
            currentTime = 0;
            spawnTime = UnityEngine.Random.Range(minTime, maxTime);
        }
    }
}
