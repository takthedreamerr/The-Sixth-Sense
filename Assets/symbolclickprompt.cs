using UnityEngine;

public class SymbolClickPrompt : MonoBehaviour
{
    public GameObject clickPrompt; // Assign the "click here" image
    public SpriteRenderer symbolSprite; // Assign the symbol's renderer

    private Symbol symbolLogic;

    void Start()
    {
        if (clickPrompt != null)
            clickPrompt.SetActive(false);

        symbolLogic = GetComponent<Symbol>();
    }

    void Update()
    {
        // Show prompt only when the symbol is visible and not yet collected
        if (!symbolLogic.IsCollected() && symbolSprite.enabled)
        {
            if (clickPrompt != null && !clickPrompt.activeSelf)
            {
                clickPrompt.SetActive(true);
            }
        }
        else
        {
            if (clickPrompt != null && clickPrompt.activeSelf)
            {
                clickPrompt.SetActive(false);
            }
        }
    }
}
