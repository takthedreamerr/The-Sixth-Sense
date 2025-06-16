 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated = false;
    public ItemSlot[] itemSlot;
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            menuActivated = !menuActivated;
            InventoryMenu.SetActive(menuActivated);
        }
    }

 
 void RefreshInventory()
{
    if (Input.GetKeyDown(KeyCode.N))
    {
        Debug.Log("N key pressed");
        menuActivated = !menuActivated;
        InventoryMenu.SetActive(menuActivated);
    }

 
     
}
    
    public void AddItem(string itemName, int quantity, Sprite itemSprite)
{
    for (int i = 0; i < itemSlot.Length; i++)
    {
        if (!itemSlot[i].isFull)
        {
            itemSlot[i].AddItem(itemName, quantity, itemSprite);
            return;
        }
    }

    Debug.LogWarning("Inventory is full. Could not add item: " + itemName);
}

}