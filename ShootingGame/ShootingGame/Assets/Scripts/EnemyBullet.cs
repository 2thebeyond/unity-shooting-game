using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5;
    //public float force = 7;
    //public Rigidbody rg;
    public GameObject explosionPrefab;

    Vector3 dir;

    void Start()
    {
        //rg = GetComponent<Rigidbody>();
        
        GameObject target = GameObject.Find("Player");
        dir = target.transform.position - transform.position;
        dir.Normalize();
    }

    void Update()
    {
        //rg.AddForce(dir * force);
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionPrefab);

        explosion.transform.position += transform.position;

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
