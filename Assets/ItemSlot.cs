 using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;

    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text quantityText;

    public bool IsFull => isFull;

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        isFull = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;

        itemImage.sprite = itemSprite;
        //itemImage.enabled = true;
    }

    public void ClearSlot()
    {
        itemName = string.Empty;
        quantity = 0;
        itemSprite = null;
        isFull = false;

        itemImage.sprite = null;
        itemImage.enabled = false;
    }
}

  