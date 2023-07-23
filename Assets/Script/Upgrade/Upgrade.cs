/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Upgrade : MonoBehaviour
{
    public GameObject UpgradeScreen;

    bool GameUpgrade;

    public static Upgrade instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        GameUpgrade = false;
    }

    void Update()
    {
        if (GameUpgrade)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void UpgradeGame()
    {
        GameUpgrade = true;
        UpgradeScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        GameUpgrade = false;
        UpgradeScreen.SetActive(false);
    }
}
*/