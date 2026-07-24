using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    private float _jumpEndTime;

    [SerializeField] private float jumpVelocity = 5f;
    [SerializeField] private float jumpDuration = 0.5f;

    public bool IsGrounded;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnDrawGizmos()
    {
        SpriteRenderer spriteRenderer = spriteRenderer = GetComponent<SpriteRenderer>();
        Gizmos.color = Color.red;

        float y = spriteRenderer.bounds.extents.y;
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - y);

        Gizmos.DrawLine(origin, origin + Vector2.down * 0.1f);
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

        float x = Input.GetAxis("Horizontal");

        float verticalVelocity = rb.linearVelocity.y;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            _jumpEndTime = Time.time + jumpDuration;
        }
        if (Input.GetKey(KeyCode.Space) && Time.time < _jumpEndTime)
        {
            verticalVelocity = jumpVelocity;
        }

        rb.linearVelocity = new Vector2(x, verticalVelocity);
    }
}
