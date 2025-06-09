 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    // ====== ITEM DATA ====== //
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;

    // ==== ITEM SLOT ==== //
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        isFull = true;

        // Update UI elements
        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
    }

    public void ClearSlot()
    {
        itemName = string.Empty;
        quantity = 0;
        itemSprite = null;
        isFull = false;

        // Clear UI elements
        quantityText.text = string.Empty;
        quantityText.enabled = false;
        itemImage.sprite = null;
        itemImage.enabled = false;
    }
}
