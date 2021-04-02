using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 0.5f;
    public GameObject explosionPrefab; 
    Vector3 dir;

    void OnEnable()
    {
        int randValue = UnityEngine.Random.Range(0, 10);

        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }

        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        // 현재점수++
        ScoreManager.Instance.Score++;

        GameObject explosion = Instantiate(explosionPrefab);

        explosion.transform.position += transform.position; 

        // 충돌 개체가 총알일 시
        if (other.gameObject.name.Contains("PlayerBullet"))
        {
            other.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            // 리스트에 총알 삽입
            player.bulletObjectPool.Add(other.gameObject);
        }

        else
        {
            Destroy(other.gameObject);
        }
        gameObject.SetActive(false);

        EnemyManager enemy = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        enemy.enemyObjectPool.Add(other.gameObject);
    } 
}
