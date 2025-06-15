using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Image characterImage;
    public Button continueButton;

    [Header("Dialogue Content")]
    public string[] dialogueLines;
    public Sprite characterSprite;
    public float typingSpeed = 0.05f;

    [Header("Signposting")]
    public GameObject casefileArrow;        // The arrow sprite (assign in Inspector)
    public GameObject player;
    public GameObject signpostingObject;    // The floating object to pan to
    private CameraPan cameraPan;

    private int currentLine = 0;
    private Coroutine typingCoroutine;
    private bool isTyping = false;

    void Start()
    {
        cameraPan = Camera.main.GetComponent<CameraPan>();

        // Start dialogue at the beginning
        StartDialogue();

        // Disable player movement during dialogue
        if (player != null)
            player.GetComponent<MOVEMENTS>().enabled = false;

        // Disable bouncing initially
        if (signpostingObject != null)
        {
            FloatingObject floatScript = signpostingObject.GetComponent<FloatingObject>();
            if (floatScript != null)
                floatScript.enabled = false;
        }

        // Hide arrow at start
        if (casefileArrow != null)
            casefileArrow.SetActive(false);
    }

    public void StartDialogue()
    {
        currentLine = 0;
        dialoguePanel.SetActive(true);
        characterImage.sprite = characterSprite;
        ShowLine();
    }

    public void ShowLine()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeSentence(dialogueLines[currentLine]));
        continueButton.interactable = false;

        // Show arrow if this line contains "casefile"
        if (dialogueLines[currentLine].ToLower().Contains("casefile") && casefileArrow != null)
        {
            StartCoroutine(EnableArrowAfterTyping());
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        continueButton.interactable = true;
    }

    public void NextDialogue()
    {
        if (isTyping)
        {
            SkipTyping();
            return;
        }

        if (currentLine < dialogueLines.Length - 1)
        {
            currentLine++;
            ShowLine();
        }
        else
        {
            // End of dialogue
            dialoguePanel.SetActive(false);

            if (player != null)
                player.GetComponent<MOVEMENTS>().enabled = true;

            if (cameraPan != null)
                cameraPan.StartPan();

            if (signpostingObject != null)
            {
                ObjectInteraction interaction = signpostingObject.GetComponent<ObjectInteraction>();
                if (interaction != null)
                    interaction.StartSignposting();
            }
        }
    }

    private void SkipTyping()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        dialogueText.text = dialogueLines[currentLine];
        isTyping = false;
        continueButton.interactable = currentLine < dialogueLines.Length - 1;
    }

    IEnumerator EnableArrowAfterTyping()
    {
        while (isTyping)
        {
            yield return null;
        }

        if (casefileArrow != null)
            casefileArrow.SetActive(true);
    }

    // Call this from the Casefile button’s OnClick()
    public void HideCasefileArrow()
    {
        if (casefileArrow != null)
            casefileArrow.SetActive(false);
    }
}

