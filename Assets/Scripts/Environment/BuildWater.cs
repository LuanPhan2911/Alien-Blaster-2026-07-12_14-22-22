using UnityEngine;


public class BuildWater : BaseBuild
{


    [SerializeField, Range(5, 20)] private float _size = 10f;
    [SerializeField] private SpriteRenderer _topWater;
    [SerializeField] private SpriteRenderer _bottomWater;
    [SerializeField] private BoxCollider2D _boxCollider;


    public override void UpdateLayout()
    {
        _topWater.size = new Vector2(_size, _topWater.size.y);
        _bottomWater.size = new Vector2(_size, _bottomWater.size.y);
        _boxCollider.size = new Vector2(_size, _boxCollider.size.y);
    }
}
