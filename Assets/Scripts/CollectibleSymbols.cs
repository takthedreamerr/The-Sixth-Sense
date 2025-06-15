using UnityEngine;

public class CollectibleSymbol : MonoBehaviour
{
    public bool triggersRememberMessage; // You can keep or remove this
    public string itemName; // "Mandy's couch", "Noise complaint_0", etc.
    public Sprite itemSprite; // Assign in Inspector
    public int quantity = 1;

    private bool isCollected = false;
    private SpriteRenderer spriteRenderer;
    private Collider2D symbolCollider;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        symbolCollider = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        if (isCollected) return;

        isCollected = true;
        spriteRenderer.enabled = false;
        symbolCollider.enabled = false;

        // Add to inventory
        InventoryManager.Instance.AddItemToInventory(itemName, quantity, itemSprite);

        /* If you later implement the message system, uncomment this:
        if (triggersRememberMessage && RememberMessage.Instance != null)
        {
            RememberMessage.Instance.ShowMessage();
        }
        */
    }
}