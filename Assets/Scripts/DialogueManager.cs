using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI characterNameText;
    public Image characterImage;
    public Button continueButton;
    public Button backButton;

    [Header("Dialogue Data")]
    [TextArea(3, 10)]
    public string[] dialogueLines;
    public string characterName;
    public Sprite characterSprite;

    [Header("Typing Settings")]
    public float typingSpeed = 0.05f;

    private int currentLine = 0;
    private Coroutine typingCoroutine;
    private bool isTyping = false;

    void Start()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        currentLine = 0;
        dialoguePanel.SetActive(true);
        characterNameText.text = characterName;
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

        backButton.interactable = currentLine > 0;
        continueButton.interactable = false; // Enabled after typing finishes
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
            dialoguePanel.SetActive(false);
        }
    }

    public void PreviousDialogue()
    {
        if (isTyping)
        {
            SkipTyping();
            return;
        }

        if (currentLine > 0)
        {
            currentLine--;
            ShowLine();
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



