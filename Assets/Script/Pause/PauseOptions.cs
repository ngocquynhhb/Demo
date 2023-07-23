using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseOptions : MonoBehaviour
{
    public GameObject PauseScreen;

    public GameObject UpgradeScreen;


    bool GamePaused;

    bool GameUpgrade;




    // Start is called before the first frame update
    void Start()
    {
        GamePaused = false;

        GameUpgrade = false;


    }

    public static PauseOptions Instance { get; private set; }

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

    // Update is called once per frame
    void Update()
    {
        if (GamePaused || GameUpgrade)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void PauseGame()
    {
        GamePaused = true;
        PauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        GamePaused = false;
        PauseScreen.SetActive(false);
    }

    public void UpgradeGame()
    {
        GameUpgrade = true;
        UpgradeScreen.SetActive(true);
    }

    public void FinishUpgradeGame()
    {
        GameUpgrade = false;
        UpgradeScreen.SetActive(false);
    }


    public void SaveGame()
    {
        DataPresistent.instance.SaveGame();
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Start");
    }
}
