using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public string itemName; // Set this in the Inspector (e.g., "hoodie")

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ItemCollectionManager manager = Object.FindAnyObjectByType<ItemCollectionManager>();
            if (manager != null)
            {
                manager.ItemCollected(itemName);
            }

            Destroy(gameObject); // Remove item from the scene
        }
    }
}
