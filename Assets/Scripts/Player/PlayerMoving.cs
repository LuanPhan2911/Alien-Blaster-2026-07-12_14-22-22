using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private AudioClip _walkingSound;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();

    }
    public void HandleMoving()
    {
        float horizontalInput = _player.PlayerInput.actions["Move"].ReadValue<Vector2>().x;

        float horizontalVelocity = _player.CurrentPlayerVelocity.HorizontalVelocity;
        _player.HorizontalVelocity = horizontalInput * horizontalVelocity; 

        //if (_playerJumping.IsGrounded && Mathf.Abs(horizontalInput) > 0.5f)
        //{
        //    AudioManager.Instance.Play(_walkingSound);
        //}
        //else
        //{
        //    AudioManager.Instance.Stop(_walkingSound);
        //}
    }
}
