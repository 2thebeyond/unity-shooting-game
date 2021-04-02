using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("PlayerBullet") || 
            other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);

            if (other.gameObject.name.Contains("PlayerBullet"))
            {
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
                // ¸®½ºÆ®¿¡ ÃÑ¾Ë »ðÀÔ
                player.bulletObjectPool.Add(other.gameObject);
            }

            else
            {
                EnemyManager enemy = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
                enemy.enemyObjectPool.Add(other.gameObject);
            }
        }

        else
        {
            Destroy(other.gameObject);
        }
    }
}
