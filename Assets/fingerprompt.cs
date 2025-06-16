using System.Collections;
using UnityEngine;

public class FingerPromptManager : MonoBehaviour
{
    public GameObject fingerClicker;   // UI finger image
    public AudioSource promptAudio;    // Audio that plays with it
    public float delayBeforeShowing = 3f; // Set in Inspector

    private Coroutine showRoutine;

    void Start()
    {
        if (fingerClicker != null)
            fingerClicker.SetActive(false);  

        if (promptAudio != null)
            promptAudio.Stop();              // 
    }

    
    public void TriggerFingerPrompt()
    {
        if (showRoutine != null)
            StopCoroutine(showRoutine);

        showRoutine = StartCoroutine(ShowFingerPromptAfterDelay());
    }

    private IEnumerator ShowFingerPromptAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeShowing);

        if (fingerClicker != null)
            fingerClicker.SetActive(true);

        if (promptAudio != null)
            promptAudio.Play();
    }

    public void HideFingerPrompt()
    {
        if (fingerClicker != null)
            fingerClicker.SetActive(false);

        if (promptAudio != null)
            promptAudio.Stop();
    }
}
