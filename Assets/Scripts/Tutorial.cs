using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject circlePrompt;
    public GameObject casefilePrompt;
    public GameObject inventoryPrompt;
    public GameObject finalPrompt;

    public Button symbolsButton;
    public Button casefileButton;
    public Button casefileNextButton;
    public Button inventoryButton;

    private int tutorialStep = 0;

    void Start()
    {
        // Start paused
        Time.timeScale = 0f;

        // Start first prompt
        circlePrompt.SetActive(true);

        // Assign button callbacks
        symbolsButton.onClick.AddListener(OnSymbolsClicked);
        casefileButton.onClick.AddListener(OnCasefileClicked);
        casefileNextButton.onClick.AddListener(OnCasefileNextClicked);
        inventoryButton.onClick.AddListener(OnInventoryClicked);
    }

    void OnSymbolsClicked()
    {
        if (tutorialStep == 0)
        {
            // Hide first prompt, show second
            circlePrompt.SetActive(false);
            circlePrompt.SetActive(true); // Same prompt, diff step
            tutorialStep++;
        }
        else if (tutorialStep == 1)
        {
            // Finished symbols interaction
            circlePrompt.SetActive(false);
            casefilePrompt.SetActive(true);
            tutorialStep++;
        }
    }

    void OnCasefileClicked()
    {
        if (tutorialStep == 2)
        {
            // Casefile opened
            casefilePrompt.SetActive(false);
            // Highlight next button
            AnimateButton(casefileNextButton.gameObject);
            tutorialStep++;
        }
        else if (tutorialStep == 4)
        {
            // Casefile closed
            casefilePrompt.SetActive(false);
            inventoryPrompt.SetActive(true);
            tutorialStep++;
        }
    }

    void OnCasefileNextClicked()
    {
        if (tutorialStep == 3)
        {
            // Next button pressed
            tutorialStep++;
            // Prompt to close casefile
            casefilePrompt.SetActive(true);
        }
    }

    void OnInventoryClicked()
    {
        if (tutorialStep == 5)
        {
            inventoryPrompt.SetActive(false);
            finalPrompt.SetActive(true);
            tutorialStep++;
        }
    }

    public void OnFinalPromptTap()
    {
        // Final tap
        finalPrompt.SetActive(false);
        Time.timeScale = 1f; // Resume gameplay
    }

    void AnimateButton(GameObject button)
    {
        // Example: Make it pulse to draw attention
        var anim = button.AddComponent<Animation>();
        AnimationClip clip = new AnimationClip();
        clip.legacy = true;

        AnimationCurve curve = AnimationCurve.EaseInOut(0, 1, 1, 1.2f);
        clip.SetCurve("", typeof(Transform), "localScale.x", curve);
        clip.SetCurve("", typeof(Transform), "localScale.y", curve);

        anim.AddClip(clip, "Pulse");
        anim.Play("Pulse");
    }
}
