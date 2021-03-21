using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    void Start()
    {
        Vector3 dir;
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
        Vector3 dir = Vector3.down;
        transform.position += dir * speed * Time.deltaTime;
    }

    private void onCollsionEnter(Collision other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    } 
}
