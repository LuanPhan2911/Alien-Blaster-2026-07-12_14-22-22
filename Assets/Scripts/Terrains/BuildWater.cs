using UnityEngine;


[ExecuteInEditMode]
public class BuildWater : MonoBehaviour, IExcuteEditMode
{


    [SerializeField, Range(5, 20)] private float _size = 10f;
    [SerializeField] private SpriteRenderer _topWater;
    [SerializeField] private SpriteRenderer _bottomWater;
    [SerializeField] private BoxCollider2D _boxCollider;

    private bool _isDirty = false;


    private void OnValidate()
    {
        _isDirty = true;
    }

    private void Update()
    {
        if (_isDirty)
        {
            UpdateLayout();
            _isDirty = false;
        }
    }
    private void BuildLayout()
    {

    }

    public void UpdateLayout()
    {
        _topWater.size = new Vector2(_size, _topWater.size.y);
        _bottomWater.size = new Vector2(_size, _bottomWater.size.y);
        _boxCollider.size = new Vector2(_size, _boxCollider.size.y);
    }
}
