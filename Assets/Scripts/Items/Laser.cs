using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void Toggle(bool _inOn)
    {
        _lineRenderer.enabled = _inOn;
    }
}
