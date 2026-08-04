using System.Collections;
using UnityEngine;

public class PlayerFalling : MonoBehaviour
{


    [SerializeField] private float _fallingVelocityThreshhold = 10f;
    [SerializeField] private float _fallingStunedDuration = 0.5f;
    [SerializeField] private float _fallingColliderSizeY = 1f;
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

                _player.IsStunned = true;
                StartCoroutine(FallingStunnedCorountine());

                // trigger falling sound
                _player.PlayerOneShotSound.Play(_fallingSound);


            }
        }
    }

    private IEnumerator FallingStunnedCorountine()
    {

        _player.PlayerAnimation.SetFalling(true);
        _player.PlayerSprite.SetColliderSizeY(_fallingColliderSizeY);
        yield return new WaitForSeconds(_fallingStunedDuration);

        _player.PlayerAnimation.SetFalling(false);
        _player.PlayerSprite.RestoreDefaultColliderSize();
        _player.IsStunned = false;

    }
}

