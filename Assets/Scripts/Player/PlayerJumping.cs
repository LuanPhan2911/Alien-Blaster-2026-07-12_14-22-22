using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    [SerializeField] private float _jumpVelocity = 5f;
    [SerializeField] private float _jumpDuration = 0.5f;
    [SerializeField] private float _feetSize = 1f;
    [SerializeField] private AudioClip _jumpSound;

    private Player _player;
    private PlayerClimbing _playerClimbing;
    private PlayerSwimming _playerSwimming;
    public bool IsGrounded = false;
    public bool IsOnSnow = false;
    private int _jumpRemain = 2;
    private float _jumpEndTime;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerClimbing = GetComponent<PlayerClimbing>();
        _playerSwimming = GetComponent<PlayerSwimming>();

    }

    private void Update()
    {
        CheckGrouding();
        if (_player.IsStunned) return;
        if (_playerClimbing.IsClimbing)
        {
            _jumpRemain = 1;
            return;
        }
        if (_playerSwimming.IsSwimming)
        {
            return;
        }




        _player.VerticalVelocity = _player.Rb.linearVelocityY;


        if (_player.PlayerInput.actions["Jump"].WasPressedThisFrame() && _jumpRemain > 0)
        {
            _jumpEndTime = Time.time + _jumpDuration;
            _jumpRemain--;
            _player.PlayerOneShotSound.Play(_jumpSound);

        }
        if (_player.PlayerInput.actions["Jump"].IsPressed() && Time.time < _jumpEndTime)
        {
            _player.VerticalVelocity = _jumpVelocity;

        }
    }
    private void CheckGrouding()
    {
        IsGrounded = false;
        IsOnSnow = false;

        LayerMask groundedLayerMask = _player.GetGroundLayerMask();
        Vector2 origin = new Vector2(transform.position.x,
            transform.position.y - _player.SpriteRenderer.bounds.extents.y);

        RaycastHit2D hit = Physics2D.BoxCast(origin,
            new Vector2(_feetSize, 0.1f), 0, Vector2.down, 0.1f, groundedLayerMask);

        if (hit.collider != null)
        {
            IsGrounded = true;
            IsOnSnow = hit.collider.CompareTag(Ground.SNOW_TAG);
        }

        if (IsGrounded && _player.VerticalVelocity == 0f)
        {
            _jumpRemain = 2;
        }
        _player.PlayerAnimation.SetJumping(!IsGrounded);
    }

    public void StopJump()
    {
        _jumpEndTime = Time.time;
    }

}
