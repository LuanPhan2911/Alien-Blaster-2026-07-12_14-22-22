using UnityEngine;

public class BouncePlayer : MonoBehaviour
{

    [SerializeField] private bool _onlyOnTop = true;

    [SerializeField] private float force = 5f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_onlyOnTop && Vector2.Dot(collision.contacts[0].normal, Vector2.down) < 0.5)
        {
            return;
        }

        if (collision.collider.TryGetComponent(out Player player))
        {
            player.Bounce(-collision.contacts[0].normal, force);
        }
    }
}
