using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractObject : MonoBehaviour
{
    [SerializeField] private ItemData _needItemData;

    public bool CanInteract;

    private PlayerInput _playerInput;
    public event EventHandler InteractSuccessAction;
    public event EventHandler InteractFailAction;

    private void Update()
    {
        if (CanInteract && _playerInput.actions["Interact"].WasPressedThisFrame())
        {
            if (InventoryManager.Instance.HasItem(_needItemData))
            {
                InteractSuccessAction?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                Debug.Log("Need required item");
                InteractFailAction?.Invoke(this, EventArgs.Empty);
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
