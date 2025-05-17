using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemCollector : MonoBehaviour
{
    public Text inventoryText;  // Assign this in the inspector
    private List<string> inventory = new List<string>();
    private const int maxItems = 4;

    void Start()
    {
        UpdateInventoryUI();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CollectItemUnderMouse();
        }
    }

    void CollectItemUnderMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Collectible"))
        {
            GameObject item = hit.collider.gameObject;

            if (!inventory.Contains(item.name))
            {
                inventory.Add(item.name);
                Destroy(item); // Simulate collecting the item
                Debug.Log($"Collected: {item.name}");

                UpdateInventoryUI();

                if (inventory.Count >= maxItems)
                {
                    Debug.Log("Inventory full! Loading next scene...");
                    LoadNextScene();
                }
            }
        }
    }

    void UpdateInventoryUI()
    {
        if (inventoryText != null)
        {
            inventoryText.text = "Inventory:\n";
            foreach (string item in inventory)
            {
                inventoryText.text += "1S" + item + "\n";
            }
        }
    }

    void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
}
