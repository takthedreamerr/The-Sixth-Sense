using UnityEngine;

public class ClueClick : MonoBehaviour
{
    private ClueManager clueManager;

    void Start()
    {
        clueManager = Object.FindAnyObjectByType<ClueManager>();
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