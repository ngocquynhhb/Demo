using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolSize = 5;

    private Queue<GameObject> bulletPool;

    private void Awake()
    {
        bulletPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetPooledBullet()
    {
        if (bulletPool.Count == 0)
        {
            // Tạo thêm đối tượng đạn và thêm vào pool
            GameObject bullett = Instantiate(bulletPrefab);
            bullett.SetActive(false);
            bulletPool.Enqueue(bullett);
        }

        GameObject bullet = bulletPool.Dequeue();
        bullet.SetActive(true);
        return bullet;
    }


    public void ReturnToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}

