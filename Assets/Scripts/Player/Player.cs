using System;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public const string PLAYER_TAG = "Player";
    public const string PLAYER_MASK = "Player";
    public bool IsOnSnow;
    public float HorizontalVelocity;
    public float VerticalVelocity;

    public bool IsStunned = false;

    public PlayerAnimation PlayerAnimation { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public PlayerInput PlayerInput { get; private set; }
    public PlayerOneShotSound PlayerOneShotSound { get; private set; }
    public PlayerLoopSound PlayerLoopSound { get; private set; }
    public PlayerSprite PlayerSprite { get; private set; }

    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private AudioClip _hurtSound;

    private KnockbackReceiver _knockbackReceiver;
    private DamageFlash _damageFlash;
    private PlayerClimbing _playerClimbing;
    private PlayerData _playerData;
    private PlayerSwimming _playerSwimming;
    public int Coin { get => _playerData.Coin; private set => _playerData.Coin = value; }
    public int Health { get => _playerData.Health; private set => _playerData.Health = value; }

    public static event EventHandler<int> OnCoinChanged;
    public static event EventHandler<int> OnHealthChanged;
    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        PlayerAnimation = GetComponent<PlayerAnimation>();
        PlayerInput = GetComponent<PlayerInput>();
        PlayerOneShotSound = GetComponent<PlayerOneShotSound>();
        PlayerLoopSound = GetComponent<PlayerLoopSound>();
        PlayerSprite = GetComponent<PlayerSprite>();

        _knockbackReceiver = GetComponent<KnockbackReceiver>();
        _damageFlash = GetComponent<DamageFlash>();
        _playerClimbing = GetComponent<PlayerClimbing>();
        _playerSwimming = GetComponent<PlayerSwimming>();
    }
    private void Start()
    {
        _playerData = GameManager.Instance.PlayerData;

        // Update the UI with the current coin count at the start of the game
        OnCoinChanged?.Invoke(this, Coin);
        OnHealthChanged?.Invoke(this, Health);
    }




    private void Update()
    {
        if (IsStunned)
        {
            HorizontalVelocity = 0;
            VerticalVelocity = 0;
        }
        if (_playerClimbing.IsClimbing)
        {
            HorizontalVelocity = 0;
            Rb.gravityScale = 0f;
        }
        else
        {
            Rb.gravityScale = 1;
        }
        if (_playerSwimming.IsSwimming)
        {
            VerticalVelocity = Rb.linearVelocityY;
        }



    }

    private void FixedUpdate()
    {

        if (IsStunned) return;
        if (_knockbackReceiver.IsKnockbacked) return;



        Rb.linearVelocity = new Vector2(HorizontalVelocity, VerticalVelocity);
    }



    public void AddCoin()
    {
        Coin++;
        OnCoinChanged?.Invoke(this, Coin);
    }
    public void TakeDamage()
    {
        Health--;
        PlayerOneShotSound.Play(_hurtSound);
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
    public LayerMask GetGroundLayerMask()
    {
        return _groundLayerMask;
    }



}
