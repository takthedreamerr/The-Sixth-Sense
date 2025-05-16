using UnityEngine;
using UnityEngine.UI;

public class CaseFileViewer : MonoBehaviour
{
    public GameObject caseFilePanel;
    public Button toggleButton;
    public Button backButton;
    public Button continueButton;
    public Image caseFileImage;

    public Sprite[] caseFileSprites; // Assign all 5 case file images here in the Inspector

    private int currentIndex = 0;
    private bool isPanelVisible = false;

    void Start()
    {
        caseFilePanel.SetActive(false);
        toggleButton.onClick.AddListener(ToggleCaseFilePanel);
        backButton.onClick.AddListener(ShowPreviousFile);
        continueButton.onClick.AddListener(ShowNextFile);
    }

    void ToggleCaseFilePanel()
    {
        isPanelVisible = !isPanelVisible;
        caseFilePanel.SetActive(isPanelVisible);

        if (isPanelVisible)
        {
            currentIndex = 0; // Start from the first sprite
            UpdateCaseFileDisplay();
        }
    }

    void ShowPreviousFile()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateCaseFileDisplay();
        }
    }

    void ShowNextFile()
    {
        if (currentIndex < caseFileSprites.Length - 1)
        {
            currentIndex++;
            UpdateCaseFileDisplay();
        }
    }

    void UpdateCaseFileDisplay()
    {
        caseFileImage.sprite = caseFileSprites[currentIndex];
        backButton.gameObject.SetActive(currentIndex > 0);
        continueButton.gameObject.SetActive(currentIndex < caseFileSprites.Length - 1);
    }
}
