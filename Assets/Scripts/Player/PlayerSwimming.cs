using UnityEngine;

public class PlayerSwimming : MonoBehaviour
{

    [SerializeField] private LayerMask _waterLayerMask;
    [SerializeField] private AudioClip _swimmingSound;
    private Player _player;


    private void Awake()
    {

        _player = GetComponent<Player>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_waterLayerMask.Contains(collision.gameObject.layer))
        {
            _player.IsSwimming = true;
            _player.PlayerAnimation.SetSwimming(true);

            AudioManager.Instance.Play(_swimmingSound);



        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_waterLayerMask.Contains(collision.gameObject.layer))
        {
            _player.IsSwimming = false;

            _player.PlayerAnimation.SetSwimming(false);
            AudioManager.Instance.Stop(_swimmingSound);
        }
    }
}
