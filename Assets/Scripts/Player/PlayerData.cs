using System;

[Serializable]
public class PlayerData
{
    public int Coin;
    public int Health;

    public string Name;

    public SceneLoader.Scene CurrentLevel;

    public const int MAX_HEALTH = 6;



}
