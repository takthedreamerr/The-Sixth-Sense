using UnityEngine;
using UnityEngine.UI;

public class ExpandablePanel : MonoBehaviour
{
    public GameObject panel;             // Assign your panel in the Inspector
    public Button toggleButton;          // Assign your button in the Inspector
    private bool isPanelVisible = false;

    public GameObject clickHereFinger;   // The finger sprite prompt
    public AudioSource promptAudio;      // The audio for the finger prompt

    void Start()
    {
        // Start with the panel hidden
        panel.SetActive(false);

        // Start with finger hidden
        if (clickHereFinger != null)
            clickHereFinger.SetActive(true); // Enable it here if you want it to appear at the start

        // Play the prompt audio
        if (promptAudio != null)
            promptAudio.Play();

        // Add listener to button
        toggleButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        // Toggle the panel
        isPanelVisible = !isPanelVisible;
        panel.SetActive(isPanelVisible);

        // Hide the click here finger
        if (clickHereFinger != null)
            clickHereFinger.SetActive(false);

        // Stop the prompt audio
        if (promptAudio != null)
            promptAudio.Stop();
    }
}
