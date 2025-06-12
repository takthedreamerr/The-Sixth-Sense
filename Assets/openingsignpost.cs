using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject infoPanel;
    private bool panelVisible = false;

    private FloatingObject floatingScript;
    private AudioSource audioSource;

    public FingerPromptManager fingerPromptManager;   // Assign in Inspector
    public GameObject highlightRing;                  

    void Start()
    {
        floatingScript = GetComponent<FloatingObject>();
        audioSource = GetComponent<AudioSource>();

        infoPanel.SetActive(false);

        if (audioSource != null)
            audioSource.Stop();

        if (floatingScript != null)
            floatingScript.enabled = false;

        
        if (highlightRing != null)
            highlightRing.SetActive(false);
    }

    // Called by DialogueManager after dialogue ends
    public void StartSignposting()
    {
        if (floatingScript != null)
            floatingScript.enabled = true;

        if (audioSource != null)
        {
            audioSource.loop = true;
            audioSource.Play();
        }

        
        if (highlightRing != null)
            highlightRing.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                Debug.Log("Object clicked via raycast!");

                if (!panelVisible)
                {
                    infoPanel.SetActive(true);
                    panelVisible = true;

                    if (floatingScript != null)
                        floatingScript.StopBouncing();

                    if (audioSource != null)
                        audioSource.Stop();

                    if (fingerPromptManager != null)
                        fingerPromptManager.TriggerFingerPrompt();

                    
                    if (highlightRing != null)
                        highlightRing.SetActive(false);
                }
            }
            else
            {
                if (panelVisible)
                {
                    infoPanel.SetActive(false);
                    panelVisible = false;
                }
            }
        }
    }
}
