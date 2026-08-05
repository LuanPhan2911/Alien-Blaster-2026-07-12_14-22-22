using UnityEngine;

public class WaterParalax : MonoBehaviour
{



    [SerializeField] private float _paralaxSpeed = 0.5f;
    [SerializeField] private Transform _topTransform;
    [SerializeField] private Transform _bottomTransform;
    [SerializeField] private BoxCollider2D _boxCollider2d;


    private float _startTransformX;
    private float _startOffsetColliderX;
    private float _disttance = 1f;

    private void Start()
    {
        _startTransformX = _topTransform.localPosition.x;
        _startOffsetColliderX = _boxCollider2d.offset.x;

    }

    private void Update()
    {
        _topTransform.localPosition +=
            new Vector3(Time.deltaTime * _paralaxSpeed, 0f, 0f);
        _bottomTransform.localPosition +=
            new Vector3(Time.deltaTime * _paralaxSpeed, 0f, 0f);
        _boxCollider2d.offset += new Vector2(Time.deltaTime * _paralaxSpeed, 0f);

        if (Mathf.Abs(_topTransform.localPosition.x) > _startTransformX + _disttance)
        {
            _topTransform.localPosition = new Vector3(_startTransformX, _topTransform.localPosition.y, 0f);
            _bottomTransform.localPosition = new Vector3(_startTransformX, _bottomTransform.localPosition.y, 0f);

            _boxCollider2d.offset = new Vector2(_startOffsetColliderX, _boxCollider2d.offset.y);

        }
    }
}
