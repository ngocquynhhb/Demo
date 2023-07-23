using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject goldCoinPrefab;
    public static float goldCoinSpeed = 5f;
    private int raiCount; // Số lượng quái Rai còn lại
    private ParallaxController parallaxController;
    private PlayerController playerController;
    private HealthUpButton healthUpButton;
    public static float goldCoinZ = -6f;

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        raiCount = GameObject.FindGameObjectsWithTag("Rai").Length; // Khởi tạo số lượng quái Rai
        Debug.Log(raiCount);
        parallaxController = FindObjectOfType<ParallaxController>(); // Tìm và lưu trữ tham chiếu đến ParallaxController
        playerController = FindObjectOfType<PlayerController>(); // Tìm và lưu trữ tham chiếu đến PlayerController
        healthUpButton = FindObjectOfType<HealthUpButton>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("upgradeCountttt" + HealthUpButton.upgradeCount + HealthUpButton.isUpgradeGold);
        if (collision.gameObject.CompareTag("Rai"))
        {
            FindObjectOfType<GameManager>().IncreaseRai();
            Instantiate(explosionPrefab, collision.gameObject.transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);

            raiCount--; // Giảm số lượng quái Rai còn lại

             if (raiCount == 0)
            {
                SpawnController spawnController = FindObjectOfType<SpawnController>();
               
                    spawnController.SpawnBoss(); // Sinh ra quái BigRai khi bắn hết quái Rai
                    parallaxController.BossRaiAppeared(); // Gọi phương thức BossRaiAppeared() của ParallaxController
                   // playerController.StopAnimation(); // Gọi phương thức StopAnimation() của PlayerController

                    // Tạo vàng
                    GameObject goldCoin = Instantiate(goldCoinPrefab, collision.transform.position, Quaternion.identity);

                    // Random vị trí bay ra
                    float randomX = Random.Range(-1f, 1f); // Phạm vi random theo trục X
                    float randomY = Random.Range(0.5f, 1f); // Phạm vi random theo trục Y
                    Vector2 randomDirection = new Vector2(randomX, randomY).normalized;

                    // Đặt vận tốc nảy của vàng
                    Rigidbody2D goldCoinRb = goldCoin.GetComponent<Rigidbody2D>();
                    goldCoinRb.velocity = randomDirection * goldCoinSpeed;

                    // Đặt vị trí Z của vàng để nằm trên các đối tượng khác
                    Vector3 goldCoinPosition = goldCoin.transform.position;
                    goldCoinPosition.z = goldCoinZ;
                    goldCoin.transform.position = goldCoinPosition;

                HandleGoldUpgrade();

            }
            else
            {
                // Tạo vàng
                GameObject goldCoin = Instantiate(goldCoinPrefab, collision.transform.position, Quaternion.identity);

                // Random vị trí bay ra
                float randomX = Random.Range(-1f, 1f); // Phạm vi random theo trục X
                float randomY = Random.Range(0.5f, 1f); // Phạm vi random theo trục Y
                Vector2 randomDirection = new Vector2(randomX, randomY).normalized;

                // Đặt vận tốc nảy của vàng
                Rigidbody2D goldCoinRb = goldCoin.GetComponent<Rigidbody2D>();
                goldCoinRb.velocity = randomDirection * goldCoinSpeed;

                // Đặt vị trí Z của vàng để nằm trên các đối tượng khác
                Vector3 goldCoinPosition = goldCoin.transform.position;
                goldCoinPosition.z = goldCoinZ;
                goldCoin.transform.position = goldCoinPosition;

                HandleGoldUpgrade();

            }
        }else if (collision.gameObject.CompareTag("Drone"))
        {
            FindObjectOfType<GameManager>().IncreaseRai();
            Instantiate(explosionPrefab, collision.gameObject.transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);

            raiCount--; // Giảm số lượng quái Rai còn lại

            if (raiCount == 0)
            {
                SpawnController spawnController = FindObjectOfType<SpawnController>();

                spawnController.SpawnBoss(); // Sinh ra quái BigRai khi bắn hết quái Rai
                parallaxController.BossRaiAppeared(); // Gọi phương thức BossRaiAppeared() của ParallaxController
                                                      // playerController.StopAnimation(); // Gọi phương thức StopAnimation() của PlayerController

                // Tạo vàng
                GameObject goldCoin = Instantiate(goldCoinPrefab, collision.transform.position, Quaternion.identity);

                // Random vị trí bay ra
                float randomX = Random.Range(-1f, 1f); // Phạm vi random theo trục X
                float randomY = Random.Range(0.5f, 1f); // Phạm vi random theo trục Y
                Vector2 randomDirection = new Vector2(randomX, randomY).normalized;

                // Đặt vận tốc nảy của vàng
                Rigidbody2D goldCoinRb = goldCoin.GetComponent<Rigidbody2D>();
                goldCoinRb.velocity = randomDirection * goldCoinSpeed;

                // Đặt vị trí Z của vàng để nằm trên các đối tượng khác
                Vector3 goldCoinPosition = goldCoin.transform.position;
                goldCoinPosition.z = goldCoinZ;
                goldCoin.transform.position = goldCoinPosition;

                HandleGoldUpgrade3();
            }
            else
            {
                // Tạo vàng
                GameObject goldCoin = Instantiate(goldCoinPrefab, collision.transform.position, Quaternion.identity);

                // Random vị trí bay ra
                float randomX = Random.Range(-1f, 1f); // Phạm vi random theo trục X
                float randomY = Random.Range(0.5f, 1f); // Phạm vi random theo trục Y
                Vector2 randomDirection = new Vector2(randomX, randomY).normalized;

                // Đặt vận tốc nảy của vàng
                Rigidbody2D goldCoinRb = goldCoin.GetComponent<Rigidbody2D>();
                goldCoinRb.velocity = randomDirection * goldCoinSpeed;

                // Đặt vị trí Z của vàng để nằm trên các đối tượng khác
                Vector3 goldCoinPosition = goldCoin.transform.position;
                goldCoinPosition.z = goldCoinZ;
                goldCoin.transform.position = goldCoinPosition;

                HandleGoldUpgrade3();

            }
        }
        else if (collision.gameObject.CompareTag("BigRai"))
        {
            gameObject.SetActive(false);
            FindObjectOfType<HeathBarController>().DecreaseHealth(1f);
           // parallaxController.BossRaiAppeared(); // Gọi phương thức BossRaiAppeared() của ParallaxController
            //playerController.StopAnimation(); // Gọi phương thức StopAnimation() của PlayerController
        }
        else if (collision.gameObject.CompareTag("bossbullet"))
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
        raiCount = GameObject.FindGameObjectsWithTag("Rai").Length;
        int droneCount = GameObject.FindGameObjectsWithTag("Drone").Length;
        raiCount += droneCount;
    }
    private void HandleGoldUpgrade()
    {
        Debug.Log("upgradeCountttt" + HealthUpButton.upgradeCount + HealthUpButton.isUpgradeGold);
        int goldAmount = HealthUpButton.upgradeCount;
        if (HealthUpButton.isUpgradeGold || goldAmount > 0)
        {
            goldAmount = 1 + HealthUpButton.upgradeCount;
            if (goldAmount > 0)
            {
                FindObjectOfType<GameManager>().IncreaseGold(goldAmount);
            }
        }
        else
        {
            FindObjectOfType<GameManager>().IncreaseGold();
        }
    }
   

    private void HandleGoldUpgrade3()
    {
        int goldAmount = HealthUpButton.upgradeCount;
        if (HealthUpButton.isUpgradeGold || goldAmount > 0)
        {
            goldAmount = 1 + HealthUpButton.upgradeCount;
            if (goldAmount > 0)
            {
                FindObjectOfType<GameManager>().IncreaseGold(goldAmount+1);
            }
        }
        else
        {
            FindObjectOfType<GameManager>().IncreaseGold2();
        }
    }
  

}

