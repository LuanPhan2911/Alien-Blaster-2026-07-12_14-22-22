using UnityEngine;


[ExecuteInEditMode]
public class WaterArea : MonoBehaviour
{
    private bool _isDirty = false;

    [SerializeField, Range(5, 20)] private float _size = 10f;

    [SerializeField] private SpriteRenderer _topWater;
    [SerializeField] private SpriteRenderer _bottomWater;
    [SerializeField] private BoxCollider2D _boxCollider;

    private void OnValidate()
    {
        _isDirty = true;
    }

    private void Update()
    {
        if (_isDirty)
        {
            _topWater.size = new Vector2(_size, _topWater.size.y);
            _bottomWater.size = new Vector2(_size, _bottomWater.size.y);

            _boxCollider.size = new Vector2(_size, _boxCollider.size.y);
        }
    }
}
