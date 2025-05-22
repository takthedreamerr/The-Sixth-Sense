using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public string itemName; 

    private void OnMouseDown()
    {
       
        ItemCollectionManager manager = Object.FindAnyObjectByType<ItemCollectionManager>();
        if (manager != null)
        {
            manager.ItemCollected(itemName);
        }

        
        Destroy(gameObject);
    }
}

