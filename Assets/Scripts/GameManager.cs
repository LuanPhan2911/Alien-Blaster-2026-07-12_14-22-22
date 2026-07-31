using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private Player.PlayerData _playerData;



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        _playerData = new Player.PlayerData();


    }


    public Player.PlayerData GetPlayerData()
    {
        return _playerData;
    }


}
