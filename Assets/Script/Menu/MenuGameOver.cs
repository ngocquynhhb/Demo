using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameOver : MonoBehaviour
{
    [Header("Menu Buttos")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button exitButton;


    public void OnNewGameClick()
    {
        DisableMenuButtons();
        DataPresistent.instance.DeleteGameData();
        DataPresistent.instance.NewGame();
        SceneManager.LoadSceneAsync("SampleScene");

    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void DisableMenuButtons()
    {
        newGameButton.interactable = false;
    }
}
