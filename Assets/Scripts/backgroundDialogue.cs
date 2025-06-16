using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class backgroundDialouge : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI characterNameText;
    

    [Header("Dialogue Data")]
    [TextArea(3, 10)]
    public string[] dialogueLines;
   
    

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
        
        ShowLine();
    }

    public void ShowLine()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeSentence(dialogueLines[currentLine]));

        
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
       
    }
}
