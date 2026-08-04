using UnityEngine;


[ExecuteInEditMode]
public class Ladder : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _ladderMid;
    [SerializeField] private Transform _ladderMidTransform;
    [SerializeField, Range(0, 5)] private float _ladderMidHeight;
    [SerializeField] private BoxCollider2D _boxCollider2d;
    [SerializeField] private BoxCollider2D _topLadderCollider2d;

    private bool _isDirty = false;

    private void OnValidate()
    {
        _isDirty = true;
    }

    private PlayerSprite _playerSprite;
    private PlayerClimbing _playClimbing;
    private void Update()
    {
        if (_isDirty)
        {
            RebuildLayout();
            _isDirty = false;
        }

        if (_playerSprite != null && _playClimbing != null)
        {
            if (_playClimbing.IsClimbing)
            {
                _playerSprite.IgnoreCollision(_topLadderCollider2d, true);
            }
            else
            {
                _playerSprite.IgnoreCollision(_topLadderCollider2d, false);
            }
        }
    }

    private void RebuildLayout()
    {
        float startPosY = -0.5f;
        _ladderMid.size = new Vector2(_ladderMid.size.x, _ladderMidHeight);
        _ladderMidTransform.localPosition = new Vector3(0f, startPosY - _ladderMidHeight / 2, 0f);

        float startBoxColliderSizeY = 1f;
        float startBoxColliderOffset = 0f;
        _boxCollider2d.size = new Vector2(_boxCollider2d.size.x, startBoxColliderSizeY + _ladderMidHeight);
        _boxCollider2d.offset = new Vector2(_boxCollider2d.offset.x, startBoxColliderOffset - _ladderMidHeight / 2);
    }

    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (playerCollider.TryGetComponent(out PlayerClimbing playerClimbing))
        {
            playerClimbing.CanClimb = true;

            _playClimbing = playerClimbing;
            _playerSprite = playerCollider.GetComponent<PlayerSprite>();


        }
    }

    private void OnTriggerExit2D(Collider2D playerCollider)
    {
        if (playerCollider.TryGetComponent(out PlayerClimbing playerClimbing))
        {
            playerClimbing.CanClimb = false;

            _playClimbing = null;
            _playerSprite = null;


        }
    }




}
