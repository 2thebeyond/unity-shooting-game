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
        // ��������++
        ScoreManager.Instance.Score++;

        GameObject explosion = Instantiate(explosionPrefab);

        explosion.transform.position += transform.position; 

        // �浹 ��ü�� �Ѿ��� ��
        if (other.gameObject.name.Contains("PlayerBullet"))
        {
            other.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            // ����Ʈ�� �Ѿ� ����
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
