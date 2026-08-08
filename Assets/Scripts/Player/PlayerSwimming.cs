using UnityEngine;

public class PlayerSwimming : MonoBehaviour
{

    [SerializeField] private LayerMask _waterLayerMask;
    [SerializeField] private AudioClip _swimmingSound;

    private PlayerAnimation _playerAnimation;



    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();

    }

    public bool IsSwimming = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_waterLayerMask.Contains(collision.gameObject.layer))
        {
            IsSwimming = true;
            _playerAnimation.SetSwimming(true);

            AudioManager.Instance.Play(_swimmingSound);



        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_waterLayerMask.Contains(collision.gameObject.layer))
        {
            IsSwimming = false;

            _playerAnimation.SetSwimming(false);
            AudioManager.Instance.Stop(_swimmingSound);
        }
    }
}
