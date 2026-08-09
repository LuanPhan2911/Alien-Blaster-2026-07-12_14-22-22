using UnityEngine;

public class Moving : MonoBehaviour
{

    [SerializeField] private float _speed = 1f;
    [SerializeField] private Vector2 _direction = Vector2.left;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private LayerMask _wallMask;
    [SerializeField] private float _groundCheckDistance = 0.5f;
    [SerializeField] private float _wallCheckDistance = 0.25f;
    [SerializeField] private float offsetX = 0.5f;


    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = _rb.GetComponent<SpriteRenderer>();
    }

    private void OnDrawGizmos()
    {
        Vector2 offset = offsetX * _direction;
        Vector2 origin = (Vector2)transform.position + offset;
        Gizmos.DrawLine(transform.position, origin);
    }


    private void Update()
    {
        // wall check
        WallCheck();
        // ground check
        GroundCheck();


        _rb.linearVelocity = new Vector2(_direction.x * _speed, _rb.linearVelocityY);
    }


    private void FlipDirection()
    {
        _direction *= -1;
        _spriteRenderer.flipX = _direction.x == 1;

    }


    private void GroundCheck()
    {
        Vector2 offset = offsetX * _direction;
        Vector2 origin = (Vector2)transform.position + offset;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, _groundCheckDistance, _groundMask);
        if (hit.collider == null)
        {
            FlipDirection();
        }
    }
    private void WallCheck()
    {
        Vector2 offset = offsetX * _direction;
        Vector2 origin = (Vector2)transform.position + offset;
        RaycastHit2D hit = Physics2D.Raycast(origin, _direction, _wallCheckDistance, _wallMask);
        if (hit.collider)
        {
            FlipDirection();
        }
    }

}
