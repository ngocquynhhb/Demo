using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedGame : MonoBehaviour
{
    public float speed = 2.0f; // Tốc độ game mong muốn

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = speed; // Đặt tốc độ game
    }
}
