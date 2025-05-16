using UnityEngine;

public class CollectibleSymbol : MonoBehaviour
{
    public bool triggersRememberMessage; // Set this to true in Inspector for 3 symbols

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

        // Disable symbol
        spriteRenderer.enabled = false;
        symbolCollider.enabled = false;

        // Trigger "remember..." message if this symbol is marked
        //if (triggersRememberMessage && RememberMessage.Instance != null)//
        {
           // RememberMessage.Instance.ShowMessage();//
        }
    }
}

