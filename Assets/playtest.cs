using UnityEngine;

public class HoodiePlaytestInteraction : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1f;

    public GameObject firstPanel;    // Yes/No panel
    public GameObject secondPanel;   // Confirmation panel

    private Vector3 startPos;
    private bool isBouncing = false;
    private bool isClickable = false;

    void Start()
    {
        startPos = transform.position;

        if (firstPanel != null) firstPanel.SetActive(false);
        if (secondPanel != null) secondPanel.SetActive(false);

        isBouncing = false;
    }

    void Update()
    {
        // Bouncing logic
        if (isBouncing)
        {
            Vector3 tempPos = startPos;
            tempPos.y += Mathf.Sin(Time.time * Mathf.PI * frequency) * amplitude;
            transform.position = tempPos;
        }

        // Tap detection on hoodie
        if (isClickable && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                Debug.Log("Hoodie tapped (playtest)");
                if (firstPanel != null)
                    firstPanel.SetActive(true);

                isClickable = false;
            }
        }
    }

    public void OnYesClicked()
    {
        Debug.Log(" YES clicked (playtest)");

        if (firstPanel != null)
            firstPanel.SetActive(false);

        if (secondPanel != null)
            secondPanel.SetActive(true);
    }

    public void OnNoClicked()
    {
        Debug.Log(" clicked (playtest)");

        if (firstPanel != null)
            firstPanel.SetActive(false);

        StopBouncing();
    }

    public void EnableInteraction()
    {
        isBouncing = true;
        isClickable = true;
    }

    public void StopBouncing()
    {
        isBouncing = false;
        transform.position = startPos;
    }
}
