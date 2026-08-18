using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float _horizontalMaxSpeed = 5f;
    [SerializeField] private float _groundAcceleration = 10f;
    [SerializeField] private float _snowAcceleration = 1f;

    [SerializeField] private float _horizontalSwimmingSpeed = 2f;

    [SerializeField] private AudioClip _walkingSound;

    private Player _player;


    private void Awake()
    {
        _player = GetComponent<Player>();

    }
    public void HandleMoving()
    {
        float horizontalInput = _player.PlayerInput.actions["Move"].ReadValue<Vector2>().x;

        float horizontalSpeed = _player.IsSwimming ? _horizontalSwimmingSpeed : _horizontalMaxSpeed;

        float targetedHorizontalVelocity = horizontalInput * horizontalSpeed;

        //float acceleration = _playerJumping.IsOnSnow ? _snowAcceleration : _groundAcceleration;

        //_player.HorizontalVelocity = Mathf.Lerp(_player.HorizontalVelocity,
        //    targetedHorizontalVelocity, Time.deltaTime * acceleration);

        _player.HorizontalVelocity = targetedHorizontalVelocity;

        // Mathf.MoveTowards: Linearly interpolates between two values by a maximum change. 
        // Mathf.Lerp: Fast at first, then slows down as it approaches the target.
        // Mathf.SmoothDamp: Slow at first, then fast, then slow again as it approaches the target.

        //if (_playerJumping.IsGrounded && Mathf.Abs(horizontalInput) > 0.5f)
        //{
        //    AudioManager.Instance.Play(_walkingSound);
        //}
        //else
        //{
        //    AudioManager.Instance.Stop(_walkingSound);
        //}
    }
}
