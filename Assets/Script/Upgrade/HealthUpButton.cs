using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthUpButton : MonoBehaviour, IDataPresistent
{
    private Text goldText;
    private int gold ;
    private int drone;
    public Text notifyText;
    public Image notifyImg;

    private void Start()
    {
        goldText = GameManager.Instance.goldText;
            //// If no game data, start a new game with initial values
            //gold = 0; // Set your initial gold value here
            //drone = 0; // Set your initial drone value here
    }
    public void IncreaseHealth()
    {
        if (gold < 10)
        {
            notifyText.text = "Không đủ số vàng để nâng cấp";
            notifyImg.gameObject.SetActive(true);
            DataPresistent.instance.SaveGame();
            DataPresistent.instance.LoadGame();
            return;
        }
        else
        {
            gold -= 10;
            drone++;
            Debug.Log("Vang" + gold);
            Debug.Log("Mau" + drone);
            goldText.text = gold.ToString();
            GameManager.Instance.droneText.text = drone.ToString();
            GameManager.Instance.health.SetActive(false);
            SceneManager.LoadScene("SampleScene");
        }
        
    }
    public void DecreaseGold()
    {
        if (gold < 10)
        {
            return;
        }
        GameManager.Instance.DecreaseGold();
    }

    public void Exit()
    {
        DataPresistent.instance.SaveGame();
        DataPresistent.instance.LoadGame();
        GameManager.Instance.health.SetActive(false);
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void LoadData(GameData data)
    {
        this.gold = data.gold;
        this.drone = data.hp;
    }

    public void SaveData(ref GameData data)
    {
        data.gold = this.gold;
        data.hp = this.drone;
    }

}