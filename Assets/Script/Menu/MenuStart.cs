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

    public void OnLoadGameClick()
    {
        DisableMenuButtons();
        SceneManager.LoadSceneAsync("SampleScene");
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
