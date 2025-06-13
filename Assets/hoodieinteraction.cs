using UnityEngine;

public class HoodieInteraction : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1f;

    public GameObject firstPanel;    // Yes/No panel
    public GameObject secondPanel;   // Confirmation panel

    private Vector3 startPos;
    public bool isBouncing = false;
    private bool isClickable = false;
    private bool hasBeenClicked = false;
    private bool awaitingClose = false;
    private bool panelJustOpened = false;

    void Start()
    {
        startPos = transform.position;

        if (firstPanel != null) firstPanel.SetActive(false);
        if (secondPanel != null) secondPanel.SetActive(false);

        isBouncing = false;
    }

    void Update()
    {
        isBouncing = false;
        // Handle bouncing
        if (isBouncing)
        {
            Vector3 tempPos = startPos;
            tempPos.y += Mathf.Sin(Time.time * Mathf.PI * frequency) * amplitude;
            transform.position = tempPos;
        }

        // Handle click on hoodie
        if (isClickable && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                Debug.Log(" Hoodie tapped!");

                if (firstPanel != null)
                    firstPanel.SetActive(true);

                isClickable = false;
                hasBeenClicked = true;
            }
        }

        // Tap anywhere to close second panel
        if (awaitingClose && !panelJustOpened && Input.GetMouseButtonDown(0))
        {
            if (secondPanel != null)
                secondPanel.SetActive(false);

            awaitingClose = false;
            StopBouncing();
        }

        // Reset panelJustOpened after 1 frame
        if (panelJustOpened)
        {
            panelJustOpened = false;
        }
    }

    public void OnYesClicked()
    {
        Debug.Log("YES clicked");

        if (secondPanel != null)
        {
            secondPanel.SetActive(true);
            awaitingClose = true;
            panelJustOpened = true;
        }
        if (firstPanel != null)
            firstPanel.SetActive(false);

        StopBouncing();
        gameObject.SetActive(false); // Hide hoodie after adding to inventory
    }

    public void OnNoClicked()
    {
        Debug.Log(" NO clicked");

        if (firstPanel != null)
            firstPanel.SetActive(false);

        StopBouncing();
        isClickable = false;
    }

    public void StopBouncing()
    {
        isBouncing = false;
        transform.position = startPos;
    }

    // Called by FloatingObjectInteraction after panel is closed
    public void EnableInteraction()
    {
        if (!hasBeenClicked)
        {
            isBouncing = false;
            isClickable = false;
        }
    }
}

