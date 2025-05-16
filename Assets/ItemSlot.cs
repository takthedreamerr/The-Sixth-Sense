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

    // ====== UI COMPONENTS ====== //
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;

    // Adds item data to the slot and updates UI
    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        isFull = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;

        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
    }
}
