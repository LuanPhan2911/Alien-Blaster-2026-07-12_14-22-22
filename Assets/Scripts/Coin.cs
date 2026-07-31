using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private AudioClip _coinSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            // Add coin to player's score
            player.AddCoin();
            // Destroy the coin object
            gameObject.SetActive(false);

            player.PlaySound(_coinSound);


        }

    }
}
