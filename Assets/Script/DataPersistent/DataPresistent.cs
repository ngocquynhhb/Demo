using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPresistent : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private bool initializeDataIfNull = false;


    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    public GameData gameData;

    private List<IDataPresistent> dataPresistents;

    private FileDataHandler dataHandler;
    public static DataPresistent instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("...");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);

    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;

    }

    public void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataPresistents = FindAllDataPresistents();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        this.gameData = dataHandler.Load();


        if (this.gameData == null && initializeDataIfNull)
        {
            NewGame();
        }


        if (this.gameData == null)
        {
            Debug.Log("No data was found. A New Game needs to be started before data can be loaded.");
            return;
        }

        foreach (IDataPresistent dataPresistent in dataPresistents)
        {
            dataPresistent.LoadData(gameData);
        }

    }
    public void SaveGame()
    {

        if (this.gameData == null)
        {
            Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
            return;
        }

        foreach (IDataPresistent dataPresistent in dataPresistents)
        {
            dataPresistent.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
    }

    public void DeleteGameData()
    {
        dataHandler.Delete();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPresistent> FindAllDataPresistents()
    {
        IEnumerable<IDataPresistent> dataPresistents = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPresistent>();

        return new List<IDataPresistent>(dataPresistents);

    }

    public bool HasGameData()
    {
        return gameData != null;
    }
}
