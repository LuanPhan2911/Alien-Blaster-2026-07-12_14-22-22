public static class SceneLoader
{

    public enum Scene
    {
        MainMenu,
        Level1,
        Level2,
        Level3,
        Level4,
        Level5,
        Level6,
        Level7,
        Level8,
        Level9,
        Level10
    }

    public static void LoadScene(Scene scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
    }
}
