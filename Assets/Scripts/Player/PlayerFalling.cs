using System.Collections;
using UnityEngine;

public class PlayerFalling : MonoBehaviour
{


    [SerializeField] private float _fallingVelocityThreshhold = 10f;
    [SerializeField] private float _fallingStunedDuration = 0.5f;
    [SerializeField] private AudioClip _fallingSound;
    private Player _player;
    private PlayerCroching _playerCroching;

    public bool IsFalling = false;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerCroching = GetComponent<PlayerCroching>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_player.GetGroundLayerMask().Contains(collision.gameObject.layer))
        {

            if (collision.relativeVelocity.y >= _fallingVelocityThreshhold)
            {
                // trigger falling animation
                IsFalling = true;
                _playerCroching.IsCroching = true;
                StartCoroutine(FallingStunnedCorountine());

                // trigger falling sound
                AudioManager.Instance.PlayOneShot(_fallingSound);


            }
        }
    }

    private IEnumerator FallingStunnedCorountine()
    {
        yield return new WaitForSeconds(_fallingStunedDuration);
        IsFalling = false;
    }
}

