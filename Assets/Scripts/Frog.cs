using UnityEngine;

public class Frog : MonoBehaviour
{



    [SerializeField] private Vector2 _jumpForce;
    [SerializeField] private Sprite _jumpSprite;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private LayerMask _bounderyMask;
    [SerializeField] private float _jumpInterval = 3f;

    private Sprite _defaultSprite;
    private Rigidbody2D _rb;

    private SpriteRenderer _spriteRenderer;




    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _defaultSprite = _spriteRenderer.sprite;
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
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // reverse the direction of the frog when it hits a boundary
        if (_bounderyMask.Contains(collision.gameObject.layer))
        {
            _jumpForce.x = -_jumpForce.x;
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
    }
}
