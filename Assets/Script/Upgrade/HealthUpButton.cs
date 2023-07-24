using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthUpButton : MonoBehaviour, IDataPresistent
{
    private Text goldText;
    private Text droneText;
    private int gold;
    private int drone;
    public Text notifyText;
    public Image notifyImg;
    [SerializeField] private Button continueGameButton;
    public Text napdan;

    private void Start()
    {
        napdan.text = "";
        goldText = GameManager.Instance.goldText;
        droneText = GameManager.Instance.droneText;
    }
    public void IncreaseHealth()
    {

        gold = int.Parse(goldText.text.ToString());
        drone = int.Parse(droneText.text.ToString());
        if (gold < 25)
        {
            notifyText.text = "Không đủ số vàng để nâng cấp";
            notifyImg.gameObject.SetActive(true);
            PauseOptions.Instance.SaveGame();
            return;
        }
        else
        {
            gold -= 25;
            drone++;
            Debug.Log("Vang" + gold);
            Debug.Log("Mau" + drone);
            goldText.text = gold.ToString();
            GameManager.Instance.droneText.text = drone.ToString();
            PauseOptions.Instance.SaveGame();
            MenuStart.Instance.OnLoadGameClick();
            GameManager.Instance.health.SetActive(false);
            PauseOptions.Instance.FinishUpgradeGame();
        }
    }
    public static int upgradeCount  {get; set;}
    public static bool isUpgradeGold { get; set; }




    public void UpgradeGold()
    {
        upgradeCount = PlayerPrefs.GetInt("UpgradeCount", 0);
        isUpgradeGold = PlayerPrefs.GetInt("IsUpgradeGold", 0) == 1;
        gold = int.Parse(goldText.text.ToString());
        drone = int.Parse(droneText.text.ToString());
        if (gold < 30)
        {
            notifyText.text = "Không đủ số vàng để nâng cấp";
            notifyImg.gameObject.SetActive(true);
            PauseOptions.Instance.SaveGame();
            return;
        }
        else
        {
            gold -= 30;
            goldText.text = gold.ToString();
            upgradeCount++;
            isUpgradeGold = true;
            PauseOptions.Instance.SaveGame();
            //MenuStart.Instance.OnLoadGameClick();
            GameManager.Instance.health.SetActive(false);
            PauseOptions.Instance.FinishUpgradeGame();
        }
        MenuStart.Instance.ReturnToGame();
        Debug.Log("upgradeCount" + upgradeCount + isUpgradeGold);
    }


    public void OnLoadGameClick()
    {
        DataPresistent.instance.LoadGame();
    }
    
    public void DecreaseGold()
    {
        if (gold < 25)
        {
            return;
        }
        GameManager.Instance.DecreaseGold();
    }

    public void Exit()
    {

        gold = int.Parse(goldText.text.ToString());
        drone = int.Parse(droneText.text.ToString());
        GameManager.Instance.health.SetActive(false);
        PauseOptions.Instance.SaveGame();
        MenuStart.Instance.OnLoadGameClick();
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