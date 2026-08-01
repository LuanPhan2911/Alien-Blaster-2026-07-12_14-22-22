using UnityEngine;

public class Spring : MonoBehaviour
{


    [SerializeField] private Sprite _sprungSprite;

    private SpriteRenderer _spriteRenderer;
    private Sprite _originalSprite;
    private AudioSource _audioSource;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalSprite = _spriteRenderer.sprite;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            _spriteRenderer.sprite = _sprungSprite;
            _audioSource.Play();
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
