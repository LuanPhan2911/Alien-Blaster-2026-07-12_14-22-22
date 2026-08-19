using UnityEngine;

public class PlayerWallSliding : MonoBehaviour
{

    [SerializeField] private Vector2 _wallCheckSize;

    [SerializeField] private Transform _wallCheckLeft;
    [SerializeField] private Transform _wallCheckRight;

    [SerializeField] private float _sliddingSpeed = 2f;

    [SerializeField] private LayerMask _wallCheckMask;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        Gizmos.DrawWireCube(_wallCheckLeft.position, _wallCheckSize);
        Gizmos.DrawWireCube(_wallCheckRight.position, _wallCheckSize);

    }

    public void WallCheck()
    {
        _player.IsWallSling = false;
        if (_player.IsGrounded) return;

        Collider2D leftCollider = Physics2D.OverlapBox(_wallCheckLeft.position, _wallCheckSize, 0f, _wallCheckMask);
        Collider2D rightCollider = Physics2D.OverlapBox(_wallCheckRight.position, _wallCheckSize, 0f, _wallCheckMask);


        if (leftCollider != null && _player.HorizontalVelocity != 0)
        {
            _player.IsWallSling = true;
            _player.PlayerSprite.Flip(false);
            _player.VerticalVelocity = Mathf.Max(_player.Rb.linearVelocityY, -_sliddingSpeed);

        }
        else if (rightCollider != null && _player.HorizontalVelocity != 0)
        {
            _player.IsWallSling = true;
            _player.PlayerSprite.Flip(true);
            _player.VerticalVelocity = Mathf.Max(_player.Rb.linearVelocityY, -_sliddingSpeed);

        }
    }
}
