using UnityEngine;
using UnityEngine.UI;

public class ExpandablePanel : MonoBehaviour
{
    public GameObject panel;     // Assign your panel in the Inspector
    public Button toggleButton;  // Assign your button in the Inspector

    private bool isPanelVisible = false;

    void Start()
    {
        // Start with the panel hidden
        panel.SetActive(false);

        // Add listener to button
        toggleButton.onClick.AddListener(TogglePanel);
    }

    void TogglePanel()
    {
        isPanelVisible = !isPanelVisible;
        panel.SetActive(isPanelVisible);
    }
}