using UnityEngine;


[ExecuteInEditMode]
public class BuildGround : MonoBehaviour, IExecuteEditMode
{

    [SerializeField] private SpriteRenderer _groundTopSpriteRenderder;
    [SerializeField] private SpriteRenderer _groundBottomSpriteRenderer;
    [SerializeField] private Transform _groundBottomTransform;

    [SerializeField] private BoxCollider2D _groundCollider;


    [SerializeField, Range(5, 50)] private float _width = 5;

    [SerializeField, Range(10, 20)] private float _height = 10;

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
    public void UpdateLayout()
    {
        _groundTopSpriteRenderder.size = new Vector2(_width, 1);
        _groundBottomSpriteRenderer.size = new Vector2(_width, _height - 1);
        _groundCollider.size = new Vector2(_width, _height);

        float offsetY = -_height / 2;
        _groundBottomTransform.localPosition = new Vector3(0f, offsetY, 0f);


        _groundCollider.offset = new Vector2(0, offsetY + 0.5f);

    }
}
