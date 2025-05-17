using System.Collections.Generic;

using UnityEngine;



public class ItemCollectionManager : MonoBehaviour

{

    // Required item names

    private HashSet<string> requiredItems = new HashSet<string> {

        "hoodie", "rent_notice", "noise_complaint", "couch"

    };



    // Items the player has collected

    private HashSet<string> collectedItems = new HashSet<string>();



    public DoorScript doorToUnlock; // Assign in Inspector

    public GameObject darkOverlay;  // Optional: for disabling darkness

    public GameObject blockers;     // Optional: for removing movement blockers



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



        // Open the door

        if (doorToUnlock != null)

            doorToUnlock.OpenDoor();



        // Disable blockers (like tilemaps)

        if (blockers != null)

            blockers.SetActive(false);



        // Remove dark overlay or change lighting

        if (darkOverlay != null)

            darkOverlay.SetActive(false);

    }

}