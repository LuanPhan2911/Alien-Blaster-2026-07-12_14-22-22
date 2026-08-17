using UnityEngine;


public class BuildAirWall : BaseBuild
{



    [SerializeField, Range(1, 5)] private float _width = 1;
    [SerializeField, Range(5, 20)] private float _height = 5;
    [SerializeField] private Color _wallColor;

    [SerializeField] private BoxCollider2D _boxCollider;
    private void OnDrawGizmos()
    {
        Gizmos.color = _wallColor;
        float offsetY = _height / 2 - 2.5f;

        Vector3 center = new Vector3(transform.position.x, offsetY, transform.position.z);
        Gizmos.DrawCube(center, new Vector3(_width, _height, 0f));
    }
    public override void UpdateLayout()
    {
        float offsetY = _height / 2 - 2.5f;
        _boxCollider.offset = new Vector2(0, offsetY);
        _boxCollider.size = new Vector2(_width, _height);
    }



}
