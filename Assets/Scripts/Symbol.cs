using UnityEngine;

public class Symbol : MonoBehaviour
{
    public bool triggersRememberMessage = false; // Check this for the 3 special symbols
    public SpriteRenderer spriteRenderer; // The visible symbol sprite
    private bool isCollected = false;

    private void OnMouseDown()
    {
        if (!isCollected)
        {
            isCollected = true;

            // Hide symbol visually
            spriteRenderer.enabled = false;

            // Disable collider to prevent future clicks
            GetComponent<Collider2D>().enabled = false;

            // Show "Remember..." message if needed
            if (triggersRememberMessage)
            {
                SymbolManager.Instance.ShowRememberMessage();
            }

            // Notify SymbolManager that this symbol was collected
            SymbolManager.Instance.SymbolCollected();
        }
    }
}


