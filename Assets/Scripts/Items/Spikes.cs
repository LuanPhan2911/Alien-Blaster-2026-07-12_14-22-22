using UnityEngine;

public class Spikes : MonoBehaviour
{



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {

            player.TakeDamage();

            Vector2 direction = -collision.GetContact(0).normal;

            player.TakeKnockback(direction);
        }
    }
}
