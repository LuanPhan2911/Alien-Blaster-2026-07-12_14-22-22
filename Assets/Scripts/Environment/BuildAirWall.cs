using UnityEngine;

[ExecuteInEditMode]
public class BuildAirWall : MonoBehaviour, IExecuteEditMode
{



    [SerializeField, Range(1, 5)] private float _width = 1;
    [SerializeField, Range(5, 20)] private float _height = 5;

    [SerializeField] private BoxCollider2D _boxCollider;


    private bool _isDirty = false;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float offsetY = _height / 2 - 2.5f;

        Vector3 center = new Vector3(transform.position.x, offsetY, transform.position.z);
        Gizmos.DrawCube(center, new Vector3(_width, _height, 0f));
    }



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

    public void UpdateLayout()
    {
        float offsetY = _height / 2 - 2.5f;
        _boxCollider.offset = new Vector2(0, offsetY);
        _boxCollider.size = new Vector2(_width, _height);
    }



}
