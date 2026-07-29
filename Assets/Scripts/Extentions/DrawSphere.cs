using UnityEngine;

public class DrawSphere : MonoBehaviour
{

    [SerializeField] private Color _color = Color.green;

    [SerializeField] private float _radius = 1f;
    [SerializeField] private bool _isMoveable = false;

    private Vector2 _startPosition;
    private bool _isInitialized = false;


    private void Awake()
    {
        _startPosition = new Vector2(transform.position.x, transform.position.y);
        _isInitialized = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = _color;
        if (!_isInitialized || _isMoveable)
        {

            Gizmos.DrawWireSphere(transform.position, _radius);
            return;
        }
        Gizmos.DrawWireSphere(_startPosition, _radius);
    }
}
