using UnityEngine;

public class Spring : MonoBehaviour
{


    [SerializeField] private Sprite _sprungSprite;

    private SpriteRenderer _spriteRenderer;
    private Sprite _originalSprite;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalSprite = _spriteRenderer.sprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            _spriteRenderer.sprite = _sprungSprite;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            _spriteRenderer.sprite = _originalSprite;
        }
    }

}
