using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool IsGrounded;
    public const string PLAYER_TAG = "Player";
    public bool IsOnSnow;

    [SerializeField] private float _jumpVelocity = 5f;
    [SerializeField] private float _jumpDuration = 0.5f;
    [SerializeField] private float _horizontalMaxSpeed = 5f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _feetSize = 0.6f;

    [SerializeField] private float _groundAcceleration = 10f;
    [SerializeField] private float _snowAcceleration = 1f;


    private PlayerAnimation _playerAnimation;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    private AudioSource _audioSource;
    private PlayerInput _playerInput;


    private float _horizontal;
    private float _jumpEndTime;
    private int _jumpRemain;

    public int Coin { get; private set; }

    public static event EventHandler<int> OnCoinChanged;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _playerAnimation = GetComponent<PlayerAnimation>();

        _audioSource = GetComponent<AudioSource>();

        _playerInput = GetComponent<PlayerInput>();


    }

    private void OnDrawGizmos()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - spriteRenderer.bounds.extents.y);
        Gizmos.color = Color.red;
        //Gizmos.DrawLine(origin, origin + Vector2.down * 0.1f);
        Gizmos.DrawCube(origin + Vector2.down * 0.05f, new Vector3(_feetSize, 0.1f, 0));
    }



    // Update is called once per frame
    void Update()
    {
        CheckGrouding();

        float horizontalInput = _playerInput.actions["Move"].ReadValue<Vector2>().x;

        float verticalVelocity = _rb.linearVelocity.y;

        if (_playerInput.actions["Jump"].WasPressedThisFrame() && _jumpRemain > 0)
        {
            _jumpEndTime = Time.time + _jumpDuration;
            _jumpRemain--;


            _audioSource.pitch = _jumpRemain > 0 ? 1f : 1.2f;
            _audioSource.Play();
        }
        if (_playerInput.actions["Jump"].IsPressed() && Time.time < _jumpEndTime)
        {
            verticalVelocity = _jumpVelocity;
        }

        float desiredHorizontalVelocity = horizontalInput * _horizontalMaxSpeed;

        float acceleration = IsOnSnow ? _snowAcceleration : _groundAcceleration;
        _horizontal = Mathf.Lerp(_horizontal, desiredHorizontalVelocity, Time.deltaTime * acceleration);
        _rb.linearVelocity = new Vector2(_horizontal, verticalVelocity);

        UpdateSprite();
    }

    private void CheckGrouding()
    {
        IsGrounded = false;
        IsOnSnow = false;
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - _spriteRenderer.bounds.extents.y);

        RaycastHit2D hit = Physics2D.BoxCast(origin, new Vector2(_feetSize, 0.1f), 0, Vector2.down, 0.1f, _layerMask);


        if (hit.collider != null)
        {
            IsGrounded = true;
            IsOnSnow = hit.collider.CompareTag(Ground.SNOW_TAG);
        }

        if (IsGrounded && _rb.linearVelocity.y == 0f)
        {
            _jumpRemain = 2;
        }

    }

    private void UpdateSprite()
    {

        _playerAnimation.SetHorizontal(_horizontal);
        _playerAnimation.SetJumPing(!IsGrounded);


        if (_horizontal > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_horizontal < 0)
        {
            _spriteRenderer.flipX = true;
        }


    }

    public void AddCoin()
    {
        Coin++;
        OnCoinChanged?.Invoke(this, Coin);
    }
    public void PlaySound(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
