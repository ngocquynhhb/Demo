using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IEnemy
{
    private ObjectPooling objectPool;
    private GameObject bossPrefab;

    public EnemyFactory(ObjectPooling objectPool, GameObject bossPrefab)
    {
        this.objectPool = objectPool;
        this.bossPrefab = bossPrefab;
    }

    public GameObject CreateNormalEnemy(Vector3 position)
    {
        GameObject normalEnemy = objectPool.GetPooledObject();
        normalEnemy.transform.position = position;
        normalEnemy.SetActive(true);
        return normalEnemy;
    }

    public GameObject CreateBossEnemy(Vector3 position)
    {
        GameObject bossEnemy = Instantiate(bossPrefab, position, Quaternion.identity);
        bossEnemy.SetActive(true);
        return bossEnemy;
    }

    // Implement IEnemy interface
    public void Spawn(Vector3 position)
    {
        CreateBossEnemy(position);
    }
}
