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

    public List<Vector3> enemyPositions;

    public List<Vector3> dronePositions;

    public GameData()
    {
        this.gold = 0;
        this.hp = 3;
        this.enemyScore = 0;
        enemyPositions = new List<Vector3>();
        dronePositions = new List<Vector3>();
        playerPosition = new Vector3(-7f, 1f, 0f);
    }
}
