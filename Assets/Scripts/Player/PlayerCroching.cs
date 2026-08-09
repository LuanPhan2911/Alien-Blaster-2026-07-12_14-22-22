using UnityEngine;

public class PlayerCroching : MonoBehaviour
{

    public bool IsCroching = false;
    private Player _player;
    private PlayerFalling _playerFalling;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerFalling = GetComponent<PlayerFalling>();
    }

    private void Update()
    {
        if (_player.PlayerInput.actions["Move"].ReadValue<Vector2>().y < 0f || _playerFalling.IsFalling)
        {
            _player.PlayerSprite.SetCrochingCollider();
            _player.PlayerAnimation.SetCroching(true);

            IsCroching = true;
        }
        else
        {
            _player.PlayerSprite.RestoreDefaultColliderSize();
            _player.PlayerAnimation.SetCroching(false);
            IsCroching = false;
        }
    }




}
