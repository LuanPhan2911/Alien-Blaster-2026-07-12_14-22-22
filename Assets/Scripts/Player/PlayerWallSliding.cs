using UnityEngine;

public class PlayerWallSliding : MonoBehaviour
{

    [SerializeField] private Vector2 _wallCheckSize;

    [SerializeField] private Transform _wallCheckLeft;
    [SerializeField] private Transform _wallCheckRight;

    [SerializeField] private float _sliddingSpeed = 2f;

    [SerializeField] private LayerMask _wallCheckMask;

    private Player _player;
    private PlayerWallJumping _playerWallJumping;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerWallJumping = GetComponent<PlayerWallJumping>();
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        Gizmos.DrawWireCube(_wallCheckLeft.position, _wallCheckSize);
        Gizmos.DrawWireCube(_wallCheckRight.position, _wallCheckSize);

    }

    public void WallCheck()
    {
        _player.IsWallSliding = false;
        if (_player.IsGrounded || _player.IsWallJumping) return;

        Collider2D leftCollider = Physics2D.OverlapBox(_wallCheckLeft.position, _wallCheckSize, 0f, _wallCheckMask);
        Collider2D rightCollider = Physics2D.OverlapBox(_wallCheckRight.position, _wallCheckSize, 0f, _wallCheckMask);
       
        if (_player.HorizontalVelocity != 0 && (leftCollider!= null || rightCollider!=null))
        {
            // reset jump remaining
            _playerWallJumping.JumpRemaining = _player.JumpAvailable;

            _player.IsWallSliding = true;
            _player.VerticalVelocity = Mathf.Max(_player.Rb.linearVelocityY, -_sliddingSpeed);

           
            // set wall jump direction
            if (leftCollider != null)
            {
                _player.PlayerSprite.Flip(false);
                _playerWallJumping.WallJumpDirection = 1;
            }else if(rightCollider!= null)
            {
                _player.PlayerSprite.Flip(true);
                _playerWallJumping.WallJumpDirection = -1;
            }
        }

       
    }
}
