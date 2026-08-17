using System.Collections;
using UnityEngine;

public class PlayerFalling : MonoBehaviour
{


    [SerializeField] private float _fallingVelocityThreshhold = 10f;
    [SerializeField] private float _fallingStunedDuration = 0.5f;
    [SerializeField] private AudioClip _fallingSound;
    private Player _player;


    private void Awake()
    {
        _player = GetComponent<Player>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_player.GetGroundLayerMask().Contains(collision.gameObject.layer))
        {

            if (collision.relativeVelocity.y >= _fallingVelocityThreshhold)
            {
                // trigger falling animation
                _player.IsFall = true;
                StartCoroutine(FallingStunnedCorountine());
                _player.PlayerSprite.SetCrochingCollider();
                _player.PlayerAnimation.SetCroching(true);

                // trigger falling sound
                AudioManager.Instance.PlayOneShot(_fallingSound);


            }
        }
    }

    private IEnumerator FallingStunnedCorountine()
    {
        yield return new WaitForSeconds(_fallingStunedDuration);
        _player.PlayerSprite.RestoreDefaultColliderSize();
        _player.PlayerAnimation.SetCroching(false);
        _player.IsFall = false;
    }
}

