using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;

    // ������Ʈ Ǯ ũ��
    public int poolSize = 10;
    // ������Ʈ Ǯ �迭
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
        // ������Ʈ Ǯ�� �迭 ũ�⸸ŭ ����
        bulletObjectPool = new List<GameObject>();
        
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);

            // �Ѿ��� ������Ʈ Ǯ�� �Ҵ�
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