using UnityEngine;

public class ClueClick : MonoBehaviour
{
    private ClueManager clueManager;

    void Start()
    {
        clueManager = Object.FindFirstObjectByType<ClueManager>();
    }

    void OnMouseDown()
    {
        if (CompareTag("clue"))
        {
            clueManager.CollectClue();
            Destroy(gameObject);
        }
    }
}