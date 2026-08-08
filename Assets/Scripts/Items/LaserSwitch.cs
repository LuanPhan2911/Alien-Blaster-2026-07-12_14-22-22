using UnityEngine;
using UnityEngine.Events;

public class LaserSwitch : MonoBehaviour
{


    [SerializeField] private Sprite _offSwitchSprite;
    [SerializeField] private Sprite _onSwitchSprite;

    [SerializeField] private AudioClip _switchSound;

    private SpriteRenderer _currentSprite;




    public UnityEvent OnSwitchOn;
    public UnityEvent OnSwitchOff;

    private bool _isOn = false;
    private void Awake()
    {
        _currentSprite = GetComponent<SpriteRenderer>();
    }


    private void Start()
    {
        OnSwitchOff.Invoke();
        _isOn = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {


            if (player.HorizontalVelocity > 0 && !_isOn)
            {
                _currentSprite.sprite = _onSwitchSprite;
                OnSwitchOn.Invoke();
                AudioManager.Instance.PlayOneShot(_switchSound);
                _isOn = true;

            }
            else if (player.HorizontalVelocity < 0 && _isOn)
            {
                _currentSprite.sprite = _offSwitchSprite;
                OnSwitchOff.Invoke();
                AudioManager.Instance.PlayOneShot(_switchSound);
                _isOn = false;

            }

        }
    }


}
