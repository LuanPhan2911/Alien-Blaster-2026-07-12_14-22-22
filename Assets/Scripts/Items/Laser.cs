using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    private bool _isOn = false;

    [SerializeField] private Vector2 _startOffset;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _distance;


    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    private void Start()
    {

    }

    public void Toggle(bool isOn)
    {
        _isOn = isOn;
        _lineRenderer.enabled = isOn;
    }

    private void Update()
    {
        if (!_isOn) return;

        Vector2 startPoint = (Vector2)transform.position + _startOffset;
        Vector2 endPoint = startPoint + _direction * _distance;

        RaycastHit2D hit = Physics2D.Raycast(startPoint, _direction, _distance);
        if (hit.collider != null)
        {
            endPoint = hit.point;

            if (hit.collider.TryGetComponent(out ITakeLaserDamagable takeDamage))
            {
                takeDamage.TakeLaserDamage();
            }
        }



        _lineRenderer.SetPosition(0, startPoint);
        _lineRenderer.SetPosition(1, endPoint);
    }
}
