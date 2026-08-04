using UnityEngine;

public class PlayerClimbing : MonoBehaviour
{

    [SerializeField] private float _climbingSpeed = 1f;

    public bool IsClimbing = false;
    public bool CanClimb = false;

    private Player _player;
    private PlayerJumping _playerJumping;
    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerJumping = GetComponent<PlayerJumping>();
    }

    private void Update()
    {

        float verticalInput = _player.PlayerInput.actions["Move"].ReadValue<Vector2>().y;
        float horizontalInput = _player.PlayerInput.actions["Move"].ReadValue<Vector2>().x;
        if (CanClimb)
        {
            if (Mathf.Abs(verticalInput) > 0.1f)
            {
                IsClimbing = true;
                _player.PlayerAnimation.SetClimbing(true);
                _player.PlayerAnimation.StartCurrentAnimation();
            }
            else
            {
                // player is not climbing
                if (IsClimbing)
                {
                    _player.PlayerAnimation.PauseCurrentAnimation();
                }

                if (IsClimbing && _playerJumping.IsGrounded && Mathf.Abs(horizontalInput) > 0.1f)
                {
                    Debug.Log("Player want to movement");
                    IsClimbing = false;
                    _player.PlayerAnimation.SetClimbing(false);
                    _player.PlayerAnimation.StartCurrentAnimation();

                }

                // Stop climb
                if (IsClimbing && _player.PlayerInput.actions["Jump"].IsPressed())
                {
                    Debug.Log("Player Stop climbing");
                    IsClimbing = false;
                    _player.PlayerAnimation.SetClimbing(false);
                    _player.PlayerAnimation.StartCurrentAnimation();
                }
            }
            _player.VerticalVelocity = verticalInput * _climbingSpeed;

        }
        else
        {
            IsClimbing = false;
            _player.PlayerAnimation.SetClimbing(false);
            _player.PlayerAnimation.StartCurrentAnimation();
        }
    }







}
