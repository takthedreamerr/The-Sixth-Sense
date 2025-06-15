 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated = false;
    public ItemSlot[] itemSlot;
    public static InventoryManager Instance;

    // Dictionary to track collected items by name
    private Dictionary<string, bool> collectedItems = new Dictionary<string, bool>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            menuActivated = !menuActivated;
            InventoryMenu.SetActive(menuActivated);

            // When opening inventory, refresh to show any newly collected items
            if (menuActivated)
            {
                RefreshInventoryUI();
            }
        }
    }

    public void AddItemToInventory(string itemName, int quantity, Sprite itemSprite)
    {
        // Mark item as collected
        if (!collectedItems.ContainsKey(itemName))
        {
            collectedItems.Add(itemName, true);
        }

        // Add to first available slot
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].IsFull)
            {
                itemSlot[i].AddItem(itemName, quantity, itemSprite);
                return;
            }
        }
        Debug.LogWarning("Inventory is full. Could not add item: " + itemName);
    }

    void RefreshInventoryUI()
    {
        // This ensures all collected items are visible in inventory
        // You might not need this if AddItemToInventory handles everything
    }
}