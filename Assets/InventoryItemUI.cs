using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemUI : MonoBehaviour
{
    public Image itemImage;
    public TMP_Text itemNameText;
    public TMP_Text quantityText;

    public void Setup(string name, int quantity, Sprite sprite)
    {
        itemNameText.text = name;
        quantityText.text = quantity.ToString();
        itemImage.sprite = sprite;
    }

    public void UpdateQuantity(int newQuantity)
    {
        quantityText.text = newQuantity.ToString();
    }
}