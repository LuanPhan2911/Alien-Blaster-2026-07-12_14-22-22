using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private SceneLoader.Scene scene;



    public void LoadLevel()
    {
        SceneLoader.LoadScene(scene);
    }
}
