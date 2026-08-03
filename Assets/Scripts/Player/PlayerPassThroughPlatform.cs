using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPassThroughPlatform : MonoBehaviour
{


    [SerializeField] private Collider2D _colider2d;

    [SerializeField] private float _delayBeforePassThrough = 0.1f;

    [SerializeField] private float _passThroughDuration = 0.5f;

    [SerializeField] private float _passThroughAnimationDuration = 0.3f;





    private OneWayPlatformPassThrough _currentPlatform = null;

    private PlayerInput _playerInput;
    private PlayerAnimation _playerAnimation;



    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }


    private void Update()
    {

        if (_currentPlatform != null)
        {
            if (_playerInput.actions["PassThrough"].IsPressed())
            {
                _currentPlatform.PassThrough(_colider2d, _passThroughDuration);
                StartCoroutine(PassThroughAnimationCorountine());
            }
        }
    }



    private IEnumerator PassThroughAnimationCorountine()
    {

        yield return new WaitForSeconds(_delayBeforePassThrough);
        _playerAnimation.SetClimbing(true);
        yield return new WaitForSeconds(_passThroughAnimationDuration);
        _playerAnimation.SetClimbing(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out OneWayPlatformPassThrough platform))
        {
            _currentPlatform = platform;


        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out OneWayPlatformPassThrough platform))
        {
            if (_currentPlatform == platform)
            {
                _currentPlatform = null;

            }
        }
    }



}
