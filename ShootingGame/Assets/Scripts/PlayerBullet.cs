using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
    
    }

    void Update()
    {
        Vector3 dir = Vector3.up;
        transform.position += dir * speed * Time.deltaTime;
    }
}
