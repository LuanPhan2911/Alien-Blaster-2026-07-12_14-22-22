using UnityEngine;

public class Brick : MonoBehaviour
{

    [SerializeField] private ParticleSystem _brickBreakParticle;
    [SerializeField] private AudioClip _brickBreakSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {

            Vector2 nornal = collision.contacts[0].normal;

            float dotVal = Vector2.Dot(nornal, Vector2.up);


            if (dotVal > 0.5f)
            {
                Destroy(gameObject);
                ParticleSystem particle = Instantiate(_brickBreakParticle, transform.position, Quaternion.identity);
                player.PlayerOneShotSound.Play(_brickBreakSound);

            }



        }
    }
}
