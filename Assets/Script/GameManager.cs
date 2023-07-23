using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour, IDataPresistent
{
    public Text goldText;
    public int gold;

    public Text droneText;
    public int drone = 3;

    public Text raiText;
    public int rai;

    public Text HS;
    public int hs;

    public GameObject health;

    private HighScore highScores;

    public DataPresistent dataPresistent;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        droneText.text = drone.ToString();
        goldText.text = gold.ToString();
        raiText.text = rai.ToString();
        HS.text = hs.ToString();
        // Load high score từ lưu trữ
        LoadHighScore();
    }

    public void IncreaseGold()
    {
        gold++;
        goldText.text = gold.ToString();
    }
    public void IncreaseGold(int amount)
    {
        gold += amount;
        goldText.text = gold.ToString();
    }
    public void IncreaseGold2()
    {
        gold+=2;
        goldText.text = gold.ToString();
    }
    public void IncreaseGold5()
    {
        gold += 5;
        goldText.text = gold.ToString();
    }
    public void DecreaseGold()
    {
        gold -= 10;
        goldText.text = gold.ToString();
    }
    public void DecreaseDrone()
    {
        drone--;
        droneText.text = drone.ToString();

        // Check if the player's score exceeds the current high score
        if (rai > hs)
        {
            // Update the high score value
            hs = rai;

            // Save the new high score
            SaveHighScore();

            // Update the high score text with the new high score value
            HS.text = hs.ToString();
        }

        // Check if the player is out of drones
        if (drone <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }
    public void IncreaseRai()
    {
        rai++;
        raiText.text = rai.ToString();
       
    }
    public void IncreaseDrone()
    {
        drone++;
        droneText.text = drone.ToString();
    }
    public void LoadData(GameData data)
    {
        this.gold = data.gold;
        this.drone = data.hp;
        this.rai = data.enemyScore;
    }

    public void SaveData(ref GameData data)
    {
        data.gold = this.gold;
        data.hp = this.drone;
        data.enemyScore = this.rai;
    }

    private void LoadHighScore()
    {
        // Kiểm tra xem tệp JSON high score có tồn tại không
        if (File.Exists(GetHighScoreFilePath()))
        {
            // Đọc tệp JSON và chuyển đổi thành đối tượng HighScore
            string json = File.ReadAllText(GetHighScoreFilePath());
            highScores = JsonUtility.FromJson<HighScore>(json);

            // Update the hs variable with the loaded high score
            hs = highScores.highScore;

            // Update the high score text
            HS.text = hs.ToString();
        }
        else
        {
            // Nếu không có tệp JSON, tạo một đối tượng HighScore mới với giá trị mặc định
            highScores = new HighScore();
            highScores.highScore = 0;
            hs = 0;

            // Update the high score text with the default value
            HS.text = hs.ToString();
        }
    }

    private void SaveHighScore()
    {
        // Update the high score value in the highScore object
        highScores.highScore = hs;

        // Chuyển đổi đối tượng HighScore thành chuỗi JSON
        string json = JsonUtility.ToJson(highScores);

        // Lưu chuỗi JSON vào tệp
        File.WriteAllText(GetHighScoreFilePath(), json);

        // Update the high score text
        HS.text = hs.ToString();
    }

    private string GetHighScoreFilePath()
    {

        // Đường dẫn tới tệp JSON lưu trữ high score
        return Application.persistentDataPath + "/highscore.json";

    }
}

