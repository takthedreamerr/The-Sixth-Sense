using UnityEngine;

public class SymbolClickPrompt : MonoBehaviour
{
    
    public GameObject clickPrompt;

    
    public SpriteRenderer symbolSprite;

    public Symbol symbolLogic;

    private void Start()
    {
        // Hide prompt at start
        if (clickPrompt != null)
            clickPrompt.SetActive(true);

        symbolLogic = GetComponent<Symbol>();
    }

    private void Update()
    {
        // Safety check for references
        if (clickPrompt == null || symbolLogic == null || symbolSprite == null)
            return;

        // If symbol is visible and not yet collected, show prompt
        if (symbolSprite.enabled && !symbolLogic.IsCollected())
        {
            if (!clickPrompt.activeSelf)
                clickPrompt.SetActive(true);
        }
        else
        {
            if (clickPrompt.activeSelf)
                clickPrompt.SetActive(false);
        }
    }
}
