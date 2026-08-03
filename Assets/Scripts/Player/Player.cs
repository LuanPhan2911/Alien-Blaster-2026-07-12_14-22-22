using System;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool IsGrounded;
    public const string PLAYER_TAG = "Player";
    public const string PLAYER_MASK = "Player";
    public bool IsOnSnow;

    [SerializeField] private float _jumpVelocity = 5f;
    [SerializeField] private float _jumpDuration = 0.5f;
    [SerializeField] private float _horizontalMaxSpeed = 5f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _feetSize = 0.6f;

    [SerializeField] private float _groundAcceleration = 10f;
    [SerializeField] private float _snowAcceleration = 1f;

    [SerializeField] private AudioClip _hurtSound;




    private PlayerAnimation _playerAnimation;
    private KnockbackReceiver _knockbackReceiver;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    private DamageFlash _damageFlash;

    private AudioSource _audioSource;
    private PlayerInput _playerInput;


    private float _horizontalVelocity;
    private float _verticalVelocity;
    private float _jumpEndTime;
    private int _jumpRemain;
    private PlayerData _playerData;


    public int Coin { get => _playerData.Coin; private set => _playerData.Coin = value; }
    public int Health { get => _playerData.Health; private set => _playerData.Health = value; }

    public static event EventHandler<int> OnCoinChanged;
    public static event EventHandler<int> OnHealthChanged;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _playerAnimation = GetComponent<PlayerAnimation>();

        _audioSource = GetComponent<AudioSource>();

        _playerInput = GetComponent<PlayerInput>();

        _knockbackReceiver = GetComponent<KnockbackReceiver>();
        _damageFlash = GetComponent<DamageFlash>();


    }
    private void Start()
    {
        _playerData = GameManager.Instance.PlayerData;

        // Update the UI with the current coin count at the start of the game
        OnCoinChanged?.Invoke(this, Coin);
        OnHealthChanged?.Invoke(this, Health);
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

        _verticalVelocity = _rb.linearVelocityY;


        if (_playerInput.actions["Jump"].WasPressedThisFrame() && _jumpRemain > 0)
        {
            _jumpEndTime = Time.time + _jumpDuration;
            _jumpRemain--;

            _audioSource.Play();
        }
        if (_playerInput.actions["Jump"].IsPressed() && Time.time < _jumpEndTime)
        {
            _verticalVelocity = _jumpVelocity;
        }

        float targetedHorizontalVelocity = horizontalInput * _horizontalMaxSpeed;
        float acceleration = IsOnSnow ? _snowAcceleration : _groundAcceleration;

        _horizontalVelocity = Mathf.Lerp(_horizontalVelocity, targetedHorizontalVelocity, Time.deltaTime * acceleration);

        // Mathf.MoveTowards: Linearly interpolates between two values by a maximum change. 
        // Mathf.Lerp: Fast at first, then slows down as it approaches the target.
        // Mathf.SmoothDamp: Slow at first, then fast, then slow again as it approaches the target.

        UpdateSprite();
    }
    private void FixedUpdate()
    {
        if (_knockbackReceiver.IsKnockbacked) return;
        _rb.linearVelocity = new Vector2(_horizontalVelocity, _verticalVelocity);
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

        _playerAnimation.SetHorizontal(_horizontalVelocity);
        _playerAnimation.SetJumping(!IsGrounded);


        if (_horizontalVelocity > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_horizontalVelocity < 0)
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


    public void TakeDamage()
    {
        Health--;

        _audioSource.PlayOneShot(_hurtSound);

        OnHealthChanged?.Invoke(this, Health);

        _damageFlash.Flash();
        if (Health <= 0)
        {
            // Handle player death (e.g., reload the scene, show game over screen, etc.)

            SceneLoader.LoadScene(SceneLoader.Scene.MainMenu);

        }
    }
    public void TakeKnockback(Vector2 direction)
    {
        _knockbackReceiver.Knockback(direction);

    }




}
