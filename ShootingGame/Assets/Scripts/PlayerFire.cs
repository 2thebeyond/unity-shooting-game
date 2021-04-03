using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;

    // 오브젝트 풀 크기
    public int poolSize = 10;
    // 오브젝트 풀 배열
    public List<GameObject> bulletObjectPool;

    public GameObject firePosition;

    void Awake()
    {
#if UNITY_ANDROID
        GameObject.Find("Joystick canvas XYBZ").SetActive(true);
#elif UNITY_EDITOR || UNITY_STANDALONE
        GameObject.Find("Joystick canvas XYBZ").SetActive(false);
#endif
    }

    void Start()
    {
        // 오브젝트 풀을 배열 크기만큼 생성
        bulletObjectPool = new List<GameObject>();
        
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);

            // 총알을 오브젝트 풀에 할당
            bulletObjectPool.Add(bullet);
            bullet.SetActive(false);
        }
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetButtonDown("Fire1")) 
        {
            Fire();
        }
#endif
    }

    public void Fire()
    {
        if (bulletObjectPool.Count > 0)
        {
            GameObject bullet = bulletObjectPool[0];

            bullet.SetActive(true);

            bulletObjectPool.Remove(bullet);

            bullet.transform.position = firePosition.transform.position;
        }
    }
}