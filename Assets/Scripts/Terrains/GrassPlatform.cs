using UnityEngine;

[ExecuteInEditMode]
public class GrassPlatform : MonoBehaviour
{

    [SerializeField] private Transform _grassLeft;
    [SerializeField] private Transform _grassRight;

    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField, Range(0, 10)] private int _grassMidSize = 0;

    private bool _isDirty = false;


    private void OnValidate()
    {
        _isDirty = true;
    }
    private void Update()
    {
        if (_isDirty)
        {
            RebuildLayout();
            _isDirty = false;
        }
    }

    private void RebuildLayout()
    {
        float startPosX = 0.5f;
        SpriteRenderer grassMidSpriteRenderder = GetComponent<SpriteRenderer>();

        grassMidSpriteRenderder.size = new Vector2(_grassMidSize, grassMidSpriteRenderder.size.y);

        float offset = _grassMidSize * 0.5f;

        // move the left and right grass to the correct position
        if (_grassLeft != null && _grassRight != null)
        {
            _grassLeft.localPosition = new Vector3(-startPosX - offset, 0, 0);
            _grassRight.localPosition = new Vector3(startPosX + offset, 0, 0);
        }

        _boxCollider2D.size = new Vector2(_grassMidSize + 2, _boxCollider2D.size.y);





    }
}
