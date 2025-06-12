using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Image characterImage;
    public Button continueButton;

    public string[] dialogueLines;
    public Sprite characterSprite;

    public float typingSpeed = 0.05f;

    private int currentLine = 0;
    private Coroutine typingCoroutine;
    private bool isTyping = false;

    // References for signposting sequence
    public GameObject player;
    public GameObject signpostingObject;   // Assign the bouncing/clickable object
    private CameraPan cameraPan;

    void Start()
    {
        cameraPan = Camera.main.GetComponent<CameraPan>();

        // Start dialogue at the beginning
        StartDialogue();

        // Disable player movement while dialogue is active
        player.GetComponent<MOVEMENTS>().enabled = false;

        // Disable bouncing initially (handled in ObjectInteraction script)
        signpostingObject.GetComponent<FloatingObject>().enabled = false;
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
            // Dialogue ends
            dialoguePanel.SetActive(false);

            // Re-enable player movement
            player.GetComponent<MOVEMENTS>().enabled = true;

            // Start the signposting sequence:
            
            cameraPan.StartPan();

            
            ObjectInteraction interaction = signpostingObject.GetComponent<ObjectInteraction>();
            if (interaction != null)
            {
                interaction.StartSignposting();
            }
        }
    }

    private void SkipTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        dialogueText.text = dialogueLines[currentLine];
        isTyping = false;
        continueButton.interactable = currentLine < dialogueLines.Length - 1;
    }
}
