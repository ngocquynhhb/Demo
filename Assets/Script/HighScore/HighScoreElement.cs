using System;

[Serializable]
public class HighScoreElement 
{
    public string playerName;
    public string score;

    public HighScoreElement(string playerName, string score)
    {
        this.playerName = playerName;
        this.score = score;
    }
}
