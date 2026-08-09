using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    [SerializeField] private List<ItemData> _listItemData = new List<ItemData>();


    public void AddItem(ItemData itemData)
    {
        _listItemData.Add(itemData);
    }

    public bool HasItem(ItemData itemData)
    {
        return _listItemData.Contains(itemData);
    }

    public void ResetInventory()
    {
        _listItemData.Clear();
    }

}
