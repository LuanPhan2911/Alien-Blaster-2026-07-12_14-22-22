using UnityEngine;

public class Brick : MonoBehaviour, ITakeLaserDamagable
{

    [SerializeField] private ParticleSystem _brickBreakParticle;
    [SerializeField] private AudioClip _brickBreakSound;


    [SerializeField] private float _destructionTime = 1f;
    private float _takenDamageTime = 0f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {

            Vector2 nornal = collision.contacts[0].normal;

            float dotVal = Vector2.Dot(nornal, Vector2.up);


            if (dotVal > 0.5f)
            {
                player.GetComponent<PlayerJumping>().StopJump();

                DestroySelf();
            }



        }
    }
    private void DestroySelf()
    {
        ParticleSystem particle = Instantiate(_brickBreakParticle, transform.position, Quaternion.identity);
        AudioManager.Instance.PlayOneShot(_brickBreakSound);
        Destroy(gameObject);
    }

    public void TakeLaserDamage()
    {
        _takenDamageTime += Time.deltaTime;

        if (_takenDamageTime > _destructionTime)
        {
            DestroySelf();
        }
    }
}
