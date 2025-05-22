using System.Collections;
using UnityEngine;
using TMPro; 

public class DialogueOnItemsCollected : MonoBehaviour
{
   
    public GameObject dialoguePanel;                
    public TextMeshProUGUI dialogueText;            

    
    [TextArea(2, 5)]
    public string message;                          
    public float displayDuration = 5f;              
    public float typingSpeed = 0.05f;               

    private Coroutine typingCoroutine;

    private void Start()
    {
        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);
    }

    public void ShowDialogue()
    {
        if (dialoguePanel == null || dialogueText == null) return;

        dialoguePanel.SetActive(true);
        dialogueText.text = "";

        
        typingCoroutine = StartCoroutine(TypeText(message));
    }

    private IEnumerator TypeText(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        
        yield return new WaitForSeconds(displayDuration);
        dialoguePanel.SetActive(false);
    }
}
