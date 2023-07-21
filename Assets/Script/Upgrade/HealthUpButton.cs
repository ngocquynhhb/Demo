using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthUpButton : MonoBehaviour, IDataPresistent
{
    private int gold;
    private int drone;
    public Text notifyText;
    public Image notifyImg;

    public void IncreaseHealth()
    {
        if (gold < 30)
        {
            notifyText.text = "Không đủ số vàng để nâng cấp";
            notifyImg.gameObject.SetActive(true);
            DataPresistent.instance.SaveGame();
            DataPresistent.instance.LoadGame();
            return;
        }
        GameManager.Instance.IncreaseDrone();
        SceneManager.LoadScene("SampleScene");
    }
    public void DecreaseGold()
    {
        if (gold < 30)
        {
            return;
        }
        GameManager.Instance.DecreaseGold();
    }

    public void Exit()
    {
        DataPresistent.instance.SaveGame();
        DataPresistent.instance.LoadGame();
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
    }

}