using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime;
    public float minTime = 0.5f;
    public float maxTime = 1.5f;
    public float spawnTime = 1.0f;
    public GameObject enemyPrefab;

    // 오브젝트 풀 크기
    public int poolSize = 10;
    // 오브젝트 풀 배열
    public List<GameObject> enemyObjectPool;
    public Transform[] spawnPoints;

    void Start()
    {
        spawnTime = Random.Range(minTime, maxTime);

        enemyObjectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);

            enemyObjectPool.Add(enemy);
            enemy.SetActive(false);
        }
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > spawnTime)
        {
            if (enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];

                enemy.SetActive(true);

                int index = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].transform.position;

                enemyObjectPool.Remove(enemy);
            }
            currentTime = 0;
            spawnTime = Random.Range(minTime, maxTime);
        }
    }
}
