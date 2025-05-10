 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated = false;

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
}