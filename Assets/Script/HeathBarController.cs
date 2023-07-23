using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeathBarController : MonoBehaviour, IDataPresistent
{
    public Image foreground; // Hình ảnh foreground
    public float maxHealth = 5f; // Sức mạnh tối đa
    private float health; // Sức mạnh hiện tại
    private int enemyCount; // Số lượng quái



    private void Start()
    {
        health = maxHealth;
        enemyCount = GameObject.FindGameObjectsWithTag("Rai").Length;
        UpdateHealthUI();
    }

    public void DecreaseHealth(float amount)
    {
        health -= amount;
        UpdateHealthUI();
        if (health <= 0)
        {
            DestroyEnemy();
        }
        if (health == 0)
        {
            GameManager.Instance.IncreaseGold5();
            PauseOptions.Instance.UpgradeGame();
            GameManager.Instance.health.SetActive(false);
            PauseOptions.Instance.SaveGame();
            //SceneManager.LoadScene("Upgrade");
        }
    }

    private void UpdateHealthUI()
    {
        Debug.Log("Foreground: " + foreground);
        float fillValue = health / maxHealth;
        Debug.Log("Fill Value: " + fillValue);
        foreground.fillAmount = health / maxHealth;
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public bool IsAllEnemiesDestroyed()
    {
        return enemyCount <= 0;
    }

    public void DecreaseEnemyCount()
    {
        enemyCount--;
    }

    public void LoadData(GameData data)
    {
       GameManager.Instance.LoadData(data);
    }

    public void SaveData(ref GameData data)
    {
        GameManager.Instance.SaveData(ref data);
    }
}
