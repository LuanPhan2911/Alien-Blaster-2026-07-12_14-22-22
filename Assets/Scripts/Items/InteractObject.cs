using UnityEngine;
using UnityEngine.InputSystem;

public class InteractObject : MonoBehaviour
{
    [SerializeField] private ItemData _needItemData;

    public bool CanInteract;

    private PlayerInput _playerInput;

    private void Update()
    {
        if (CanInteract && _playerInput.actions["Interact"].WasPressedThisFrame())
        {
            if (InventoryManager.Instance.HasItem(_needItemData))
            {
                Debug.Log("Unlock");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Need required item");
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            CanInteract = true;
            _playerInput = player.PlayerInput;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            CanInteract = false;
            _playerInput = null;
        }
    }

}
