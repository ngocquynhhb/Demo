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
    private int gold;

    public Text droneText;
    private int drone = 3;

    public Text raiText;
    private int rai;

    private HighScore highScore;

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
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        droneText.text = drone.ToString();
        goldText.text = gold.ToString(); 
        raiText.text = rai.ToString();
        // Load high score từ lưu trữ
        LoadHighScore();
    }
    public void IncreaseGold()
    {
        gold++;
        goldText.text = gold.ToString();
    }
    public void IncreaseGold5()
    {
        gold += 5;
        goldText.text = gold.ToString();
    }
    public void DecreaseGold()
    {
        gold -= 30;
        goldText.text = gold.ToString();
    }
    public void DecreaseDrone()
    {
        drone--;
        droneText.text = drone.ToString();
        if (drone <= 0)
        {
            if (rai > highScore.highScore)
            {
                highScore.highScore = rai;
                SaveHighScore();
            }
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
            highScore = JsonUtility.FromJson<HighScore>(json);
        }
        else
        {
            // Nếu không có tệp JSON, tạo một đối tượng HighScore mới với giá trị mặc định
            highScore = new HighScore();
            highScore.highScore = 0;
        }
    }

    private void SaveHighScore()
    {
        // Chuyển đổi đối tượng HighScore thành chuỗi JSON
        string json = JsonUtility.ToJson(highScore);

        // Lưu chuỗi JSON vào tệp
        File.WriteAllText(GetHighScoreFilePath(), json);
    }

    private string GetHighScoreFilePath()
    {
        // Đường dẫn tới tệp JSON lưu trữ high score
        return Application.persistentDataPath + "/highscore.json";
    }
}

