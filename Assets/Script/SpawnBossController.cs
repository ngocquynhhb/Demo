using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossController : MonoBehaviour
{
    public GameObject bossPrefab;
    public GameObject health;
    public float yPosition = -1.93f;

    private void Start()
    {
        health.SetActive(false);
    }
    public void SpawnBoss()
    {
        health.SetActive(true);
        Instantiate(bossPrefab, new Vector3(7.08f, yPosition, 0f), Quaternion.identity);
    }
}
