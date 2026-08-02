using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public PlayerData PlayerData { get; private set; }





    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);


        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name != SceneLoader.Scene.MainMenu.ToString())
        {
            SaveGame();
        }
    }

    private void InitPlayerData()
    {
        PlayerData = new PlayerData();
        PlayerData.Coin = 0;
        PlayerData.Health = PlayerData.MAX_HEALTH;
    }



    public void NewGame()
    {
        InitPlayerData();
        SceneLoader.LoadScene(SceneLoader.Scene.Level1);
    }

    public void SaveGame()
    {
        string data = JsonUtility.ToJson(PlayerData);

        PlayerPrefs.SetString("PlayerData", data);
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            string data = PlayerPrefs.GetString("PlayerData");
            PlayerData = JsonUtility.FromJson<PlayerData>(data);
        }
        else
        {
            InitPlayerData();
        }

        SceneLoader.LoadScene(SceneLoader.Scene.Level1);
    }
}
