using System.Collections.Generic;

[System.Serializable]
public class HighScoreList
{
    public List<HighScore> highScores;

    public HighScoreList()
    {
        highScores = new List<HighScore>();
    }
}