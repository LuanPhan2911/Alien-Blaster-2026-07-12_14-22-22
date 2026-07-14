using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody2D rb;

    private float _jumpEndTime;

    [SerializeField] private float jumpVelocity = 5f;
    [SerializeField] private float jumpDuration = 0.5f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");

        float verticalVelocity = rb.linearVelocity.y;

        if (Input.GetKeyDown(KeyCode.Space))
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
