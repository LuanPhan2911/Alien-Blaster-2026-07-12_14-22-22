using UnityEngine;

public class PlayerJumping : MonoBehaviour
{

    [SerializeField] private float _jumpVelocity = 4f;
    [SerializeField] private float _airJumpVelocity = 2f;
    [SerializeField] private float _maxJumpDurationPress = 0.5f;

    [SerializeField] private AudioClip _jumpSound;

    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheckTransform;
    [SerializeField] private Vector2 _groundCheckSize = new Vector2(1, 0.2f);

    [SerializeField] private int _maxJumps = 2;


    private Player _player;
    private int _jumpRemaining;

    private float _duration;
    private bool _isJumpPress;


    private void Awake()
    {
        _player = GetComponent<Player>();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(_groundCheckTransform.position, _groundCheckSize);
    }

    public void HandleJumpVelocity()
    {
        _player.VerticalVelocity = _player.Rb.linearVelocityY;
        _player.Rb.gravityScale = _player.GravityScale;
    }
    public void HandleJump()
    {

        if (_player.PlayerInput.actions["Jump"].WasPressedThisFrame() && _jumpRemaining > 0)
        {
            _jumpRemaining--;
            _isJumpPress = true;
            _duration = Time.time + _maxJumpDurationPress;
            AudioManager.Instance.PlayOneShot(_jumpSound);
        }

        if (_player.PlayerInput.actions["Jump"].IsPressed() && Time.time < _duration)
        {

            if (_jumpRemaining == 1)
            {
                _player.VerticalVelocity = _jumpVelocity;
            }
            else if (_jumpRemaining == 0)
            {
                _player.VerticalVelocity = _airJumpVelocity;
            }


        }
        else
        {
            _isJumpPress = false;
        }
    }

    public void GroundCheck()
    {
        _player.IsGrounded = false;

        LayerMask groundMask = _player.GetGroundLayerMask();

        Collider2D collider = Physics2D.OverlapBox(_groundCheckTransform.position, _groundCheckSize, 0f, groundMask);

        if (collider != null && !collider.isTrigger && !_isJumpPress)
        {
            _player.IsGrounded = true;
            _jumpRemaining = _maxJumps;
        }

    }



}
