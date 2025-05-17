using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated = false;
    public ItemSlot[] itemSlot;
    public InventoryDescriptionPanel descriptionPanel; // Reference this in the Inspector

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            menuActivated = !menuActivated;
            InventoryMenu.SetActive(menuActivated);
        }
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isFull)
            {
                itemSlot[i].AddItem(itemName, quantity, itemSprite);

                // Update description panel
                if (descriptionPanel != null)
                {
                    descriptionPanel.ShowDescription(itemName, itemDescription);
                }

                // Open inventory
                InventoryMenu.SetActive(true);
                return;
            }
        }

        Debug.LogWarning("Inventory is full. Could not add item: " + itemName);
    }

    internal void AddItem(string itemName, int quantity, Sprite sprite) => throw new NotImplementedException();
}
