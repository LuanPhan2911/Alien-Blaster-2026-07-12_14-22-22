using UnityEngine;



public class BuildLadder : BaseBuild
{


    [SerializeField] private SpriteRenderer _ladderMidSprite;
    [SerializeField] private Transform _ladderMidTransform;
    [SerializeField] private BoxCollider2D _boxCollider2d;
    [SerializeField, Range(0, 5)] private float _ladderMidHeight;


    public override void UpdateLayout()
    {
        float startPosY = -0.5f;
        _ladderMidSprite.size = new Vector2(_ladderMidSprite.size.x, _ladderMidHeight);
        _ladderMidTransform.localPosition = new Vector3(0f, startPosY - _ladderMidHeight / 2, 0f);

        float startBoxColliderSizeY = 1f;
        float startBoxColliderOffset = 0f;
        _boxCollider2d.size = new Vector2(_boxCollider2d.size.x, startBoxColliderSizeY + _ladderMidHeight);
        _boxCollider2d.offset = new Vector2(_boxCollider2d.offset.x, startBoxColliderOffset - _ladderMidHeight / 2);
    }
}
