using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SpawnController : MonoBehaviour, IDataPresistent
{
    public ObjectPooling objectPool;
    public Transform playerTransform;
    public float minDistanceBetweenEnemies = 3f;
    public float maxDistanceBetweenEnemies = 10f;
    public int totalNumberOfEnemies = 10;
    public float yPosition = -3.321175f;
    public SpawnBossController bossSpawnController;
    public GameObject bossPrefab;
    GameData gameData = DataPresistent.instance.gameData;
    private EnemyFactory enemyFactory;


    private void Start()
    {
        if (gameData.enemyPositions.Count != 0)
        {
            return;
        }
        enemyFactory = new EnemyFactory(objectPool, bossPrefab);

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
                GameObject enemy;

                enemy = enemyFactory.CreateNormalEnemy(spawnPosition.position);

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
            spawnPositionObject.transform.position = new Vector3((startPosition + i * distance) + 12, yPosition, 0f);
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

    public void SaveData(ref GameData data)
    {
        // Create a new GameData object if it doesn't exist
        if (data == null)
        {
            data = new GameData();
        }

        // Clear the enemy position list in the GameData to store new data
        data.enemyPositions.Clear();

        // Iterate over all spawned enemies and store their positions in the GameData object
        List<GameObject> spawnedEnemies = objectPool.GetSpawnedObjects();
        foreach (GameObject enemy in spawnedEnemies)
        {
            data.enemyPositions.Add(enemy.transform.position);
        }
    }

    public void LoadData(GameData data)
    {
        if (data == null)
        {
            return;
        }
        int totalEnemies = data.enemyPositions.Count;
        for (int i = 0; i < totalEnemies; i++)
        {
            Vector3 enemyPosition = data.enemyPositions[i];

            GameObject prefab = objectPool.GetPooledObject();
            prefab.transform.position = enemyPosition;
            prefab.SetActive(true);
        }
    }
}
