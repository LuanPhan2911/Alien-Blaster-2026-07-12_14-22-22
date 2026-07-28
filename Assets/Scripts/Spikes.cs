using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {

            SceneManager.LoadScene(0);
        }
    }
}
