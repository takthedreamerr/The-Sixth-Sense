// type final answer based on collected letters
using UnityEngine;
using UnityEngine.UI;

public class ClueManager : MonoBehaviour
{
    public int totalClues = 5;                  // Total number of clues in the scene
    private int collectedClues = 0;

    public GameObject inputPanel;              // Panel that contains the input field + button
    public InputField answerInputField;        // InputField for player to type the answer
    public Text clueMessageText;               // Text to show hint or status

    void Start()
    {
        inputPanel.SetActive(false);
        clueMessageText.text = "Type Final Decipherd Wordss";
    }

    public void CollectClue()
    {
        collectedClues++;

        if (collectedClues >= totalClues)
        {
            clueMessageText.text = "Type final answer based on collected letters";
            inputPanel.SetActive(true);
        }
    }

    public void SubmitAnswer()
    {
        string answer = answerInputField.text.Trim().ToLower();

        if (answer == "offense" || answer == "office")
        {
            Debug.Log("Progress to suspect apartment");
            clueMessageText.text = "Correct! Progress to suspect apartment.";
        }
        else
        {
            clueMessageText.text = "Incorrect answer. Try again.";
        }
    }
}