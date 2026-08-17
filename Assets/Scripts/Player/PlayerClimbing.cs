using UnityEngine;

public class PlayerClimbing : MonoBehaviour
{

    [SerializeField] private float _climbingSpeed = 1f;
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
                _player.IsClimbing = true;
                _player.PlayerAnimation.SetClimbing(true);
                _player.PlayerAnimation.StartCurrentAnimation();
                _player.VerticalVelocity = verticalInput * _climbingSpeed;
            }
            else
            {
                // player is not climbing
                if (_player.IsClimbing)
                {
                    _player.VerticalVelocity = 0f;
                    _player.PlayerAnimation.PauseCurrentAnimation();
                }

                if (_player.IsClimbing && _player.IsGrounded && Mathf.Abs(horizontalInput) > 0.1f)
                {
                    Debug.Log("Player want to movement");
                    _player.IsClimbing = false;
                    _player.PlayerAnimation.SetClimbing(false);
                    _player.PlayerAnimation.StartCurrentAnimation();

                }

                // Stop climb
                if (_player.IsClimbing && _player.PlayerInput.actions["Jump"].IsPressed())
                {
                    Debug.Log("Player Stop climbing");
                    _player.IsClimbing = false;
                    _player.PlayerAnimation.SetClimbing(false);
                    _player.PlayerAnimation.StartCurrentAnimation();
                    _player.VerticalVelocity = 0f;
                }
            }




        }
        else
        {
            _player.IsClimbing = false;
            _player.PlayerAnimation.SetClimbing(false);
            _player.PlayerAnimation.StartCurrentAnimation();

        }
    }







}
