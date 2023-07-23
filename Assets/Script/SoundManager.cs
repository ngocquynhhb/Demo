using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip gunshot, jumping, enemydie, helicopter, rbrunning;
    static AudioSource audioSource;

    void Start()
    {
        gunshot = Resources.Load<AudioClip>("GunShot");
        jumping = Resources.Load<AudioClip>("Jumping");
        jumping = Resources.Load<AudioClip>("Jumping1");
        enemydie = Resources.Load<AudioClip>("EnemyDie");
        helicopter = Resources.Load<AudioClip>("Helicopter");
        rbrunning = Resources.Load<AudioClip>("RobotRunning");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "gunshot":
                audioSource.PlayOneShot(gunshot);
                break;
            case "jumping":
                audioSource.PlayOneShot(jumping);
                break;
            case "jumping1":
                audioSource.PlayOneShot(jumping);
                break;
            case "enemydie":
                audioSource.PlayOneShot(enemydie);
                break;
            case "helicopter":
                audioSource.PlayOneShot(helicopter);
                break;
            case "rbrunning":
                audioSource.PlayOneShot(rbrunning);
                break;
        }
    }
}
