using UnityEngine;

public class Frog : MonoBehaviour
{



    [SerializeField] private Vector2 _jumpForce;
    [SerializeField] private Vector2 _jumpForceHasTarget;

    [SerializeField] private Sprite _jumpSprite;
    [SerializeField] private LayerMask _groundLayerMask;

    [SerializeField] private float _jumpInterval = 3f;
    [SerializeField] private float _jumIntervalHasTarget = 1.5f;

    [SerializeField] private float _actionRadius = 5f;
    [SerializeField] private float _offset = 0.5f;


    [SerializeField] private float detectionRadius = 4f;

    [SerializeField] private float _facingDirection = -1; // 1 for right, -1 for left
    private AudioSource _audioSource;

    public bool HasTarget { get; private set; }



    private Sprite _defaultSprite;
    private Rigidbody2D _rb;

    private SpriteRenderer _spriteRenderer;

    private Vector2 _startPosition;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _defaultSprite = _spriteRenderer.sprite;
        _startPosition = new Vector2(transform.position.x, transform.position.y);
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        float interval = HasTarget ? _jumIntervalHasTarget : _jumpInterval;
        InvokeRepeating(nameof(Jump), interval, interval);
    }

    private void Jump()
    {
        Vector2 jumpForce = HasTarget ? _jumpForceHasTarget : _jumpForce;

        jumpForce.x *= _facingDirection; // Apply facing direction to the x component of the jump force
        _rb.AddForce(jumpForce, ForceMode2D.Impulse);
        _spriteRenderer.sprite = _jumpSprite;




    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // change the sprite back to the default sprite when the frog lands on the ground
        if (_groundLayerMask.Contains(collision.gameObject.layer))
        {

            HasTarget = false;
            _spriteRenderer.sprite = _defaultSprite;
            _audioSource.Play();
            // reverse the jump force if the frog is outside the action radius



            float distanceFromStart = Vector2.Distance(_startPosition, transform.position);

            if (distanceFromStart > _actionRadius - _offset)
            {
                Vector2 direction = _startPosition - (Vector2)transform.position;
                _facingDirection = direction.x < 0 ? -1 : 1;
            }
            else
            {
                DetectPlayer();

                // Flip the sprite based on the facing direction
            }
            _spriteRenderer.flipX = _facingDirection > 0;
        }
    }

    private void DetectPlayer()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, detectionRadius,
            Vector2.zero, 0f, LayerMask.GetMask("Player"));


        if (hit.collider != null && hit.collider.TryGetComponent(out Player player))
        {
            Vector2 direction = player.transform.position - transform.position;

            HasTarget = true;


            _facingDirection = direction.x < 0 ? -1 : 1;
        }

    }

}
