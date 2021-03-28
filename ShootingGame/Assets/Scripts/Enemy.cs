using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 0.5f;
    public GameObject explosionPrefab; 
    Vector3 dir;

    void Start()
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
        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        // 현재점수++
        sm.SetScore(sm.GetScore() + 1);

        GameObject explosion = Instantiate(explosionPrefab);

        explosion.transform.position += transform.position; 

        Destroy(other.gameObject);
        Destroy(gameObject);
    } 
}
