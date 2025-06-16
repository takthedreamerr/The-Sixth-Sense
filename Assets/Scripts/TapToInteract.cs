using UnityEngine;

public class TapToInteract : MonoBehaviour
{
    public Sprite closedSprite;
    public Sprite openSprite;

    private SpriteRenderer spriteRenderer;
    private bool isOpen = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedSprite;
    }

    void OnMouseDown()
    {
        // Toggle open/close when tapped
        isOpen = !isOpen;
        spriteRenderer.sprite = isOpen ? openSprite : closedSprite;
    }
}
