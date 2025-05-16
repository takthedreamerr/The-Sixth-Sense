  using UnityEngine;

namespace MyGame.Inventory
{
    public class Item : MonoBehaviour
    {
        [SerializeField]
        private string itemName;

        [SerializeField]
        private int quantity;

        [SerializeField]
        private Sprite sprite;

        private InventoryManager inventoryManager;

        void Start()
        {
            inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                inventoryManager.AddItem(itemName, quantity, sprite);
                Destroy(gameObject);
            }
        }
    }
}
