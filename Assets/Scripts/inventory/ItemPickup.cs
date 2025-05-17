using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemName;
    public int quantity = 1;
    public Sprite itemSprite;
    [TextArea] public string itemDescription;

    private InventoryManager inventoryManager;
    private ItemCollectionManager itemCollectionManager;
    private ItemPickupUIManager uiManager;

    void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
        itemCollectionManager = FindAnyObjectByType<ItemCollectionManager>();
        uiManager = FindAnyObjectByType<ItemPickupUIManager>();
    }

    void OnMouseDown()
    {
        if (uiManager != null)
        {
            uiManager.ShowConfirmation(this);
        }
    }

    public void AddToInventory()
    {
        if (inventoryManager != null)
        {
            inventoryManager.AddItem(itemName, quantity, itemSprite, itemDescription);
        }

        if (itemCollectionManager != null)
        {
            itemCollectionManager.ItemCollected(itemName);
        }

        Destroy(gameObject);
    }

    public void LeaveItemInScene()
    {
        if (uiManager != null)
        {
            uiManager.HideConfirmation();
        }
    }
}
