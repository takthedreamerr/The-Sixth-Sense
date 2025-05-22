using System.Collections.Generic;
using UnityEngine;

public class ItemCollectionManager : MonoBehaviour
{
   
    private HashSet<string> requiredItems = new HashSet<string> {
        "hoodie", "rent_notice", "noise_complaint", "couch"
    };

    private HashSet<string> collectedItems = new HashSet<string>();

    [Header("Scene References")]
    public DoorScript doorToUnlock; 
    public GameObject darkOverlay;  
    public GameObject blockers;     

    [Header("Dialogue After Collection")]
    public DialogueOnItemsCollected dialogueAfterItems; 

    public void ItemCollected(string itemName)
    {
        if (requiredItems.Contains(itemName) && !collectedItems.Contains(itemName))
        {
            collectedItems.Add(itemName);
            Debug.Log($"Collected: {itemName}");

            if (collectedItems.Count == requiredItems.Count)
            {
                OnAllItemsCollected();
            }
        }
    }

    private void OnAllItemsCollected()
    {
        Debug.Log("All items collected!");

        
        if (doorToUnlock != null)
            doorToUnlock.OpenDoor();

        
        if (blockers != null)
            blockers.SetActive(false);

      
        if (darkOverlay != null)
            darkOverlay.SetActive(false);

        
        if (dialogueAfterItems != null)
            dialogueAfterItems.ShowDialogue();
    }
}
