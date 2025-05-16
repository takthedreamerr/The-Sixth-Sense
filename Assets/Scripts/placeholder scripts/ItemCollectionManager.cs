 using System.Collections.Generic;
using UnityEngine;

public class ItemCollectionManager : MonoBehaviour
{
    private HashSet<string> requiredItems = new HashSet<string> {
        "hoodie", "rent_notice", "noise_complaint", "couch"
    };

    private HashSet<string> collectedItems = new HashSet<string>();

    public DoorScript doorToUnlock; // Reference to door script for unlocking
    public GameObject darkOverlay;  // Optional: for disabling darkness
    public GameObject blockers;     // Optional: for removing movement blockers

    public void ItemCollected(string itemName)
    {
        // If it's one of the required items and hasn't been collected yet
        if (requiredItems.Contains(itemName) && !collectedItems.Contains(itemName))
        {
            collectedItems.Add(itemName);
            Debug.Log($"Collected: {itemName}");

            // Check if all required items have been collected
            if (collectedItems.Count == requiredItems.Count)
            {
                OnAllItemsCollected();
            }
        }
    }

    private void OnAllItemsCollected()
    {
        Debug.Log("All items collected!");

        // Trigger the door to open
        if (doorToUnlock != null)
            doorToUnlock.OpenDoor();

        // Disable blockers (optional)
        if (blockers != null)
            blockers.SetActive(false);

        // Remove dark overlay or change lighting
        if (darkOverlay != null)
            darkOverlay.SetActive(false);
    }
}
