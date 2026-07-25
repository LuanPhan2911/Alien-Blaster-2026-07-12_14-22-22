using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    private float _jumpEndTime;

    [SerializeField] private float _jumpVelocity = 5f;
    [SerializeField] private float _jumpDuration = 0.5f;
    [SerializeField] private float _horizontalVelocity = 3f;


    private PlayerAnimation _playerAnimation;



    public bool IsGrounded;
    private float _horizontal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        _playerAnimation = GetComponent<PlayerAnimation>();


    }



    // Update is called once per frame
    void Update()
    {

        Vector2 origin = new Vector2(transform.position.x, transform.position.y - spriteRenderer.bounds.extents.y);

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, 0.1f);
        if (hit.collider != null)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }

        _horizontal = Input.GetAxis("Horizontal");

        float verticalVelocity = rb.linearVelocity.y;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            _jumpEndTime = Time.time + _jumpDuration;
        }
        if (Input.GetKey(KeyCode.Space) && Time.time < _jumpEndTime)
        {
            verticalVelocity = _jumpVelocity;
        }


        rb.linearVelocity = new Vector2(_horizontal * _horizontalVelocity, verticalVelocity);

        UpdateSprite();
    }
    private void UpdateSprite()
    {
        if (IsGrounded)
        {
            if (_horizontal != 0)
            {
                _playerAnimation.SetWalking(true);
            }
            else
            {
                _playerAnimation.SetIdle();
            }
            _playerAnimation.SetJumPing(false);
        }
        else
        {
            _playerAnimation.SetJumPing(true);
        }


        if (_horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (_horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }


    }
}
