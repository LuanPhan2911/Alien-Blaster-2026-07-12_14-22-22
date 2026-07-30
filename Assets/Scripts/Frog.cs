using UnityEngine;

public class Frog : MonoBehaviour
{



    [SerializeField] private Vector2 _jumpForce;
    [SerializeField] private Sprite _jumpSprite;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private float _jumpInterval = 3f;

    [SerializeField] private float _actionRadius = 5f;
    [SerializeField] private float _offset = 0.5f;


    [SerializeField] private float detectionRadius = 4f;
    [SerializeField] private AudioSource _audioSource;

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
        InvokeRepeating(nameof(Jump), _jumpInterval, _jumpInterval);
    }

    private void Jump()
    {
        _rb.AddForce(_jumpForce);
        _spriteRenderer.sprite = _jumpSprite;




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // change the sprite back to the default sprite when the frog lands on the ground
        if (_groundLayerMask.Contains(collision.gameObject.layer))
        {

            _spriteRenderer.sprite = _defaultSprite;
            _audioSource.Play();
            // reverse the jump force if the frog is outside the action radius

            float distanceFromStart = Vector2.Distance(_startPosition, transform.position);

            if (distanceFromStart > _actionRadius - _offset)
            {
                _jumpForce.x = -_jumpForce.x;
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
            }
            else
            {
                DetectPlayer();
            }



        }
    }

    private void DetectPlayer()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, detectionRadius,
            Vector2.zero, 0f, LayerMask.GetMask("Player"));


        if (hit.collider != null && hit.collider.TryGetComponent(out Player player))
        {
            Vector2 direction = player.transform.position - transform.position;

            if (direction.x < 0)
            {
                _jumpForce.x = -Mathf.Abs(_jumpForce.x);
                _spriteRenderer.flipX = false;
            }
            else
            {
                _jumpForce.x = Mathf.Abs(_jumpForce.x);
                _spriteRenderer.flipX = true;
            }
        }
    }

}
