using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePosition;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = firePosition.transform.position;
        }
    }
}
