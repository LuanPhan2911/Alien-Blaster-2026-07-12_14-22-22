using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float _horizontalMaxSpeed = 5f;
    [SerializeField] private float _groundAcceleration = 10f;
    [SerializeField] private float _snowAcceleration = 1f;

    [SerializeField] private float _horizontalSwimmingSpeed = 2f;

    private Player _player;
    private PlayerSwimming _playerSwimming;
    private PlayerJumping _playerJumping;
    private PlayerClimbing _playerClimbing;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerSwimming = GetComponent<PlayerSwimming>();
        _playerJumping = GetComponent<PlayerJumping>();
        _playerClimbing = GetComponent<PlayerClimbing>();
    }

    private void Update()
    {
        if (_player.IsStunned) return;
        if (_playerClimbing.IsClimbing) return;

        float horizontalInput = _player.PlayerInput.actions["Move"].ReadValue<Vector2>().x;

        float horizontalSpeed = _playerSwimming.IsOnWater ? _horizontalSwimmingSpeed : _horizontalMaxSpeed;

        float targetedHorizontalVelocity = horizontalInput * horizontalSpeed;

        float acceleration = _playerJumping.IsOnSnow ? _snowAcceleration : _groundAcceleration;

        _player.HorizontalVelocity = Mathf.Lerp(_player.HorizontalVelocity,
            targetedHorizontalVelocity, Time.deltaTime * acceleration);

        // Mathf.MoveTowards: Linearly interpolates between two values by a maximum change. 
        // Mathf.Lerp: Fast at first, then slows down as it approaches the target.
        // Mathf.SmoothDamp: Slow at first, then fast, then slow again as it approaches the target.

        if (_playerJumping.IsGrounded)
        {
            if (Mathf.Abs(horizontalInput) > 0.1f)
            {
                _player.PlayerLoopSound.PlayWalkingSound();
            }
            else
            {
                _player.PlayerLoopSound.Stop();
            }
        }
    }
}
