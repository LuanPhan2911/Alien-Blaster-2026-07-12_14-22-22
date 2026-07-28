using UnityEngine;

public class WaterParalax : MonoBehaviour
{



    [SerializeField] private float _paralaxSpeed = 0.5f;

    [SerializeField] private Transform _component;


    private float _startX;
    private float _componentSize = 1f;

    private void Start()
    {
        _startX = _component.localPosition.x;

    }

    private void Update()
    {
        _component.localPosition +=
            new Vector3(Time.deltaTime * _paralaxSpeed, 0f, 0f);

        if (Mathf.Abs(_component.localPosition.x) > _startX + _componentSize)
        {
            _component.localPosition = new Vector3(_startX, 0f, 0f);
        }
    }
}
