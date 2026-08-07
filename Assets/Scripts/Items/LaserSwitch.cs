using UnityEngine;
using UnityEngine.Events;

public class LaserSwitch : MonoBehaviour
{


    [SerializeField] private Sprite _offSwitchSprite;
    [SerializeField] private Sprite _onSwitchSprite;

    private SpriteRenderer _currentSprite;




    public UnityEvent OnSwitchOn;
    public UnityEvent OnSwitchOff;
    private void Awake()
    {
        _currentSprite = GetComponent<SpriteRenderer>();
    }


    private void Start()
    {
        OnSwitchOff.Invoke();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {


            if (player.HorizontalVelocity > 0)
            {
                _currentSprite.sprite = _onSwitchSprite;
                OnSwitchOn.Invoke();

            }
            else if (player.HorizontalVelocity < 0)
            {
                _currentSprite.sprite = _offSwitchSprite;
                OnSwitchOff.Invoke();

            }

        }
    }


}
