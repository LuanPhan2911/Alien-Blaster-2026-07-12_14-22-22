using System.Collections;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private CapsuleCollider2D _playerCollider;
    private Player _player;


    [SerializeField] private float _crochingColliderSizeY = 1f;


    public float DefaultColliderSizeX { get; private set; }
    public float DefaultColliderSizeY { get; private set; }

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerCollider = GetComponent<CapsuleCollider2D>();


        DefaultColliderSizeX = _playerCollider.size.x;
        DefaultColliderSizeY = _playerCollider.size.y;
    }

    public void UpdateSprite()
    {
        if (_player.HorizontalVelocity > 0)
        {
            Flip(false);
        }
        else if (_player.HorizontalVelocity < 0)
        {
            Flip(true);
        }


    }
    public void Flip(bool isFacingRight)
    {

        _player.SpriteRenderer.flipX = isFacingRight;
    }

    public void SetColliderSizeX(float sizeX)
    {
        _playerCollider.size = new Vector2(sizeX, DefaultColliderSizeY);
    }
    public void SetColliderSizeY(float sizeY)
    {
        _playerCollider.size = new Vector2(DefaultColliderSizeX, sizeY);
    }
    public void SetColliderSize(float x, float y)
    {
        _playerCollider.size = new Vector2(x, y);
    }
    public void RestoreDefaultColliderSize()
    {
        _playerCollider.size = new Vector2(DefaultColliderSizeX, DefaultColliderSizeY);
    }

    public void IgnoreCollision(Collider2D otherCollider, float duration)
    {
        StartCoroutine(IgnoreCollisionCoroutine(otherCollider, duration));
    }
    public void IgnoreCollision(Collider2D otherCollider, bool isIgnore)
    {
        Physics2D.IgnoreCollision(_playerCollider, otherCollider, isIgnore);
    }

    private IEnumerator IgnoreCollisionCoroutine(Collider2D otherCollider, float duration)
    {
        Physics2D.IgnoreCollision(_playerCollider, otherCollider, true);

        yield return new WaitForSeconds(duration);

        Physics2D.IgnoreCollision(_playerCollider, otherCollider, false);

    }

    public void SetCrochingCollider()
    {
        SetColliderSizeY(_crochingColliderSizeY);
    }

}
