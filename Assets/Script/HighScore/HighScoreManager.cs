using System.IO;
using UnityEngine;

public class HighScoreDataManager
{
    private string filePath;

    public HighScoreDataManager(string filePath)
    {
        this.filePath = filePath;
    }

    public int LoadHighScore()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);
            return data.highScore;
        }
        else
        {
            return 0;
        }
    }

    public void SaveHighScore(int highScore)
    {
        HighScoreData data = new HighScoreData();
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
    }
}
