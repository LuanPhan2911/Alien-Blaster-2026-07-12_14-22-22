using UnityEngine;

public class PlayerSwimming : MonoBehaviour
{

    [SerializeField] private LayerMask _waterLayerMask;

    private PlayerAnimation _playerAnimation;
    private PlayerLoopSound _playerLoopSound;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerLoopSound = GetComponent<PlayerLoopSound>();
    }

    public bool IsSwimming = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_waterLayerMask.Contains(collision.gameObject.layer))
        {
            IsSwimming = true;
            _playerAnimation.SetSwimming(true);
            _playerLoopSound.PlaySwimmingSound();


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_waterLayerMask.Contains(collision.gameObject.layer))
        {
            IsSwimming = false;

            _playerAnimation.SetSwimming(false);
            _playerLoopSound.Stop();
        }
    }
}
