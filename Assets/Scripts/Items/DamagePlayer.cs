using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    [SerializeField] private bool _ignoreDamageFromTop = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_ignoreDamageFromTop && Vector2.Dot(collision.contacts[0].normal, Vector2.down) > 0.5)
        {
            return;

        }

        if (collision.collider.TryGetComponent(out Player player))
        {


            player.TakeDamage();

            Vector2 direction = -collision.GetContact(0).normal;

            player.TakeKnockback(direction);
        }
    }
}
