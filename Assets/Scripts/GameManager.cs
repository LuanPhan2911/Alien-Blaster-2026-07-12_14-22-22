using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private PlayerData _playerData;





    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        _playerData = new PlayerData();
        ResetPlayerData();

    }
    public void ResetPlayerData()
    {
        _playerData.Coin = 0;
        _playerData.Health = PlayerData.MAX_HEALTH;
    }

    public PlayerData GetPlayerData()
    {
        return _playerData;
    }


}
