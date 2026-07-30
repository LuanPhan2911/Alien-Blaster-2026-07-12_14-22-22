using UnityEngine;

public class Flag : MonoBehaviour
{

    [SerializeField] private SceneLoader.Scene nextScene;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Player.PLAYER_TAG))
        {
            SceneLoader.LoadScene(nextScene);
        }
    }
}
