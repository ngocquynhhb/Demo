using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public ObjectPooling objectPool;
    public Transform playerTransform; // Transform của player
    public float minDistanceBetweenEnemies = 3f; // Khoảng cách tối thiểu giữa các quái
    public float maxDistanceBetweenEnemies = 10f; // Khoảng cách tối đa giữa các quái
    public int totalNumberOfEnemies = 10; // Tổng số lượng quái cần spawn
    public float yPosition = -3.321175f;
    public SpawnBossController bossSpawnController;


    private void Start()
    {
        int remainingEnemies = totalNumberOfEnemies;
        float currentPosition = 0f;
        List<float> distances = GenerateRandomDistances(remainingEnemies, minDistanceBetweenEnemies, maxDistanceBetweenEnemies);

        while (remainingEnemies > 0)
        {
            // Random số lượng quái từ 1 đến số quái còn lại
            int numberOfEnemies = Mathf.Min(Random.Range(1, remainingEnemies + 1), remainingEnemies);

            float distance = distances[numberOfEnemies - 1];

            List<Transform> spawnPositions = GenerateRandomSpawnPositions(numberOfEnemies, currentPosition, distance);

            for (int i = 0; i < numberOfEnemies; i++)
            {
                Transform spawnPosition = spawnPositions[i];

                GameObject prefab = objectPool.GetPooledObject();
                prefab.transform.position = spawnPosition.position;
                prefab.SetActive(true);

                // Cập nhật vị trí hiện tại cho quái tiếp theo
                currentPosition += distance;
            }

            remainingEnemies -= numberOfEnemies;
        }
    }

    private List<float> GenerateRandomDistances(int numberOfDistances, float minDistance, float maxDistance)
    {
        List<float> distances = new List<float>();

        for (int i = 0; i < numberOfDistances; i++)
        {
            float distance = Random.Range(minDistance, maxDistance);
            distances.Add(distance);
        }

        return distances;
    }

    private List<Transform> GenerateRandomSpawnPositions(int numberOfPositions, float startPosition, float distance)
    {
        List<Transform> spawnPositions = new List<Transform>();

        for (int i = 0; i < numberOfPositions; i++)
        {
            // Tạo một GameObject tạm để lưu trữ vị trí spawn
            GameObject spawnPositionObject = new GameObject("SpawnPosition");
            spawnPositionObject.transform.position = new Vector3(startPosition + i * distance, yPosition, 0f);
            spawnPositions.Add(spawnPositionObject.transform);
        }

        return spawnPositions;
    }

    public void SpawnBoss()
    {
        if (bossSpawnController != null)
        {
            bossSpawnController.SpawnBoss();
        }
    }
}
