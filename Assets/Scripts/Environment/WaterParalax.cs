using UnityEngine;

public class WaterParalax : MonoBehaviour
{



    [SerializeField] private float _paralaxSpeed = 0.5f;
    [SerializeField] private float _maxDistanceMoving = 1f;

    private float _startTransformX;

    private void Start()
    {
        _startTransformX = transform.position.x;
    }

    private void Update()
    {
        transform.position += new Vector3(Time.deltaTime * _paralaxSpeed, 0f, 0f);
        if (transform.position.x - _maxDistanceMoving > _startTransformX)
        {
            transform.position = new Vector3(_startTransformX, transform.position.y, transform.position.z);
        }
    }
}
