using UnityEngine;

public class PlayerSwimming : MonoBehaviour
{

 
    [SerializeField] private AudioClip _swimmingSound;
    [SerializeField] private PlayerVelocity _waterVelocity;
    private Player _player;


    private void Awake()
    {

        _player = GetComponent<Player>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_player.WaterLayerMask .Contains(collision.gameObject.layer))
        {
            _player.IsSwimming = true;
            _player.PlayerAnimation.SetSwimming(true);
            _player.CurrentPlayerVelocity = _waterVelocity;

            AudioManager.Instance.Play(_swimmingSound);

           

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_player.WaterLayerMask.Contains(collision.gameObject.layer))
        {
            _player.IsSwimming = false;
            _player.CurrentPlayerVelocity = _player.DefaultPlayerVelocity;
            _player.PlayerAnimation.SetSwimming(false);
            AudioManager.Instance.Stop(_swimmingSound);
        }
    }
}
