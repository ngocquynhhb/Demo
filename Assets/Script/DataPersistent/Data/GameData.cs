using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int gold;

    public int hp;

    public int enemyScore;

    public Vector3 playerPosition;

    public GameData()
    {
        this.gold = 0;
        this.hp = 3;
        this.enemyScore = 0;
        playerPosition = new Vector3(-7f, 1f, 0f);
    }
}
