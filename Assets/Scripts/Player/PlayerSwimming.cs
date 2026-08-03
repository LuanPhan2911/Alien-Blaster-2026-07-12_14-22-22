using UnityEngine;

public class PlayerSwimming : MonoBehaviour
{

    [SerializeField] private LayerMask _waterLayerMask;

    private PlayerAnimation _playerAnimation;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    public bool IsOnWater = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_waterLayerMask.Contains(collision.gameObject.layer))
        {
            IsOnWater = true;

            _playerAnimation.SetSwimming(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_waterLayerMask.Contains(collision.gameObject.layer))
        {
            IsOnWater = false;

            _playerAnimation?.SetSwimming(false);
        }
    }
}
