using UnityEngine;

public class HouseDoor : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _topDoorSpriteRenderer;
    [SerializeField] private SpriteRenderer _bottomDoorRenderer;

    [SerializeField] private Sprite _openTopDoor;
    [SerializeField] private Sprite _openBottomDoor;


    [SerializeField] private AudioClip _openDoorSound;

    private bool _isOpen = false;
    public void SetOpenDoor()
    {
        if (_isOpen) return;

        _isOpen = true;
        _topDoorSpriteRenderer.sprite = _openTopDoor;
        _bottomDoorRenderer.sprite = _openBottomDoor;

        AudioManager.Instance.Play(_openDoorSound, transform.position);
    }
}
