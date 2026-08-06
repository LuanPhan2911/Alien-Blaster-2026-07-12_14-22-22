using UnityEngine;

public class MovingPlatform : MonoBehaviour
{




    [SerializeField] private float _speed = 0.5f;
    public Vector3 StartPosition, EndPosition;
    private void OnDrawGizmos()
    {


        Gizmos.color = Color.red;
        if (gameObject.TryGetComponent(out Platform platform))
        {
            Gizmos.DrawWireCube(StartPosition, platform.GetSize());
            Gizmos.DrawWireCube(EndPosition, platform.GetSize());
        }


    }


    [ContextMenu(nameof(SetStartPosition))]
    public void SetStartPosition()
    {
        StartPosition = transform.position;
    }
    [ContextMenu(nameof(SetEndPosition))]
    public void SetEndPosition()
    {
        EndPosition = transform.position;
    }

    private void Start()
    {
        StartPosition = transform.position;
    }
    private void Update()
    {
        float t = Mathf.PingPong(Time.time * _speed, 1f);

        transform.position = Vector3.Lerp(StartPosition, EndPosition, t);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            player.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Player>(out Player player))
        {
            player.transform.SetParent(null);
        }
    }
}
