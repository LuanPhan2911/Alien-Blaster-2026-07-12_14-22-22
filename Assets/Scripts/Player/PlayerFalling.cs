using System.Collections;
using UnityEngine;

public class PlayerFalling : MonoBehaviour
{




    private Player _player;

    [SerializeField] private float _fallingVelocityThreshhold = 10f;

    [SerializeField] private float _fallingStunedDuration = 0.5f;

    [SerializeField] private CapsuleCollider2D _playerCollider;

    [SerializeField] private float _fallingColliderSizeY = 1f;

    [SerializeField] private AudioClip _fallingSound;


    private float _defaultColliderSizeY;

    private PlayerAnimation _playerAnimation;

    public bool IsFalling = false;
    private void Awake()
    {

        _player = GetComponent<Player>();

        _playerAnimation = GetComponent<PlayerAnimation>();


        _defaultColliderSizeY = _playerCollider.size.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (_player.GetGroundLayerMask().Contains(collision.gameObject.layer))
        {

            if (collision.relativeVelocity.y >= _fallingVelocityThreshhold)
            {
                // trigger falling animation

                IsFalling = true;
                StartCoroutine(FallingStunnedCorountine());

                _player.PlaySound(_fallingSound);

                // trigger falling sound
            }
        }
    }

    private IEnumerator FallingStunnedCorountine()
    {

        _playerAnimation.SetFalling(true);
        _playerCollider.size = new Vector2(_playerCollider.size.x, _fallingColliderSizeY);
        yield return new WaitForSeconds(_fallingStunedDuration);


        _playerAnimation.SetFalling(false);
        _playerCollider.size = new Vector2(_playerCollider.size.x, _defaultColliderSizeY);


        IsFalling = false;

    }
}

