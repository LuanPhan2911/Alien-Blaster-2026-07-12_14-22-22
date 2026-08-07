using UnityEngine;



public class Ladder : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _topLadderCollider2d;


    private PlayerSprite _playerSprite;
    private PlayerClimbing _playClimbing;
    private void Update()
    {

        if (_playerSprite != null && _playClimbing != null)
        {
            if (_playClimbing.IsClimbing)
            {
                _playerSprite.IgnoreCollision(_topLadderCollider2d, true);
            }
            else
            {
                _playerSprite.IgnoreCollision(_topLadderCollider2d, false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (playerCollider.TryGetComponent(out PlayerClimbing playerClimbing))
        {
            playerClimbing.CanClimb = true;

            _playClimbing = playerClimbing;
            _playerSprite = playerCollider.GetComponent<PlayerSprite>();


        }
    }

    private void OnTriggerExit2D(Collider2D playerCollider)
    {
        if (playerCollider.TryGetComponent(out PlayerClimbing playerClimbing))
        {
            playerClimbing.CanClimb = false;

            _playClimbing = null;
            _playerSprite = null;


        }
    }




}
