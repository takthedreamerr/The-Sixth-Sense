using UnityEngine;
using UnityEngine.UI;

public class InventoryDescriptionPanel : MonoBehaviour
{
    public Text descriptionText;

    public void ShowDescription(string itemName, string description)
    {
        descriptionText.text = $"<b>{itemName}</b>\n\n{description}";
    }
}

