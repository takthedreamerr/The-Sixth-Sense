// type final answer based on collected letters
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        clueMessageText.text = "Type Final Decipherd Words";
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
        Debug.Log("Player typed: " + answer);

        if (answer == "offense" || answer == "office")
        {
            Debug.Log("Progress to suspect apartment");
            clueMessageText.text = "Correct! Progress to suspect apartment.";

            // OPTIONAL: Add a small delay before scene change
            Invoke("LoadNextScene", 2f); // waits 2 seconds
        }
        else
        {
            clueMessageText.text = "Incorrect answer. Try again.";
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(4); // replace with your actual scene name
    }
}