using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuStart : MonoBehaviour
{
    [Header("Menu Buttos")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;
    [SerializeField] private Button exitButton;


    public static MenuStart Instance { get; private set; }

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
        if (!DataPresistent.instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }
    }


    public void OnNewGameClick()
    {
        DisableMenuButtons();
        DataPresistent.instance.DeleteGameData();
        DataPresistent.instance.NewGame();
        SceneManager.LoadSceneAsync("SampleScene");

    }

    public void ReturnToGame()
    {
        DisableMenuButtons();
        SceneManager.LoadSceneAsync("SampleScene");
    }
    public void OnLoadGameClick()
    {
        ReturnToGame();
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }
}
