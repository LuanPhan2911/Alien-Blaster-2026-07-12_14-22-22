using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPassThroughPlatform : MonoBehaviour
{
    [SerializeField] private float _ignoreCollisonDuration = 0.5f;
    [SerializeField] private LayerMask _platformLayer;

    private Collider2D _currentPlatformCollider = null;
    private PlayerInput _playerInput;
    private PlayerSprite _playerSprite;
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerSprite = GetComponent<PlayerSprite>();
    }
    private void Update()
    {

        if (_currentPlatformCollider != null)
        {
            if (_playerInput.actions["PassThrough"].IsPressed())
            {
                _playerSprite.IgnoreCollision(_currentPlatformCollider, _ignoreCollisonDuration);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_platformLayer.Contains(collision.gameObject.layer))
        {
            _currentPlatformCollider = collision.collider;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (_platformLayer.Contains(collision.gameObject.layer))
        {
            _currentPlatformCollider = null;
        }
    }



}
