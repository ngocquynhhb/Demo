using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooling : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 10;

    private List<GameObject> pooledObjects = new List<GameObject>();

    private void Start()
    {
        // Tạo pool các object
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    // Lấy một object từ pool
    public GameObject GetPooledObject()
    {
        // Tìm object chưa được sử dụng (inactive)
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        // Nếu không tìm thấy object nào chưa được sử dụng, tạo thêm object mới
        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(false);
        pooledObjects.Add(newObj);
        return newObj;
    }

    // Trả object vào pool
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    // Lấy danh sách các object đã được spawn
    public List<GameObject> GetSpawnedObjects()
    {
        List<GameObject> spawnedObjects = new List<GameObject>();
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                spawnedObjects.Add(pooledObjects[i]);
            }
        }
        return spawnedObjects;
    }
}

