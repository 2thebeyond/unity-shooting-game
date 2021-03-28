using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject enemyFirePosition;

    public float randTime;
    public float fireTime = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randTime = UnityEngine.Random.Range(0.1f, 3);
        fireTime += Time.deltaTime;

        if (fireTime > randTime)
        {
            GameObject enemyBullet = Instantiate(bulletPrefab);
            enemyBullet.transform.position = enemyFirePosition.transform.position;

            randTime = UnityEngine.Random.Range(0.1f, 3);
            fireTime = 0;
        }
    }
}
