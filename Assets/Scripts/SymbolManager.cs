using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SymbolManager : MonoBehaviour
{
    public static SymbolManager Instance;

   
    public Image rememberImage;
    public float fadeDuration = 1f;
    public float displayDuration = 2f;

   
    private int symbolsCollected = 0;
    private int totalSymbols = 8;

    public GameObject answerInputPanel;
    public GameObject congratulationsPanel;
    public GameObject retryPanel;

    
    public InputField answerInputField;

  
    public DoorScript doorScript; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        SetImageAlpha(0);

       
        if (answerInputPanel != null) answerInputPanel.SetActive(false);
        if (congratulationsPanel != null) congratulationsPanel.SetActive(false);
        if (retryPanel != null) retryPanel.SetActive(false);
    }

   
    public void SymbolCollected()
    {
        symbolsCollected++;
        Debug.Log("Collected Symbol: " + symbolsCollected + "/" + totalSymbols);

        if (symbolsCollected >= totalSymbols)
        {
            Debug.Log("All symbols collected. Showing answer panel!");
            ShowAnswerPanel();
        }
    }

    public void ShowRememberMessage()
    {
        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        yield return StartCoroutine(FadeImage(0, 1, fadeDuration));
        yield return new WaitForSeconds(displayDuration);
        yield return StartCoroutine(FadeImage(1, 0, fadeDuration));
    }

    private IEnumerator FadeImage(float from, float to, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            float alpha = Mathf.Lerp(from, to, time / duration);
            SetImageAlpha(alpha);
            time += Time.deltaTime;
            yield return null;
        }
        SetImageAlpha(to);
    }

    private void SetImageAlpha(float alpha)
    {
        Color c = rememberImage.color;
        c.a = alpha;
        rememberImage.color = c;
    }

    private void ShowAnswerPanel()
    {
        answerInputPanel.SetActive(true);

        
        if (doorScript != null)
        {
            doorScript.DisableLights();
        }
        else
        {
            Debug.LogWarning("DoorScript reference is missing on SymbolManager.");
        }
    }

    
    public void CheckAnswer()
    {
        string answer = answerInputField.text.Trim().ToLower();

        answerInputPanel.SetActive(false);

        if (answer == "office" || answer == "offense")
        {
            congratulationsPanel.SetActive(true);
        }
        else
        {
            retryPanel.SetActive(true);
        }
    }

    
    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public GameObject murderWeapon; 

    public void ProceedAfterCongratulations()
    {
        
        congratulationsPanel.SetActive(false);

        
        if (murderWeapon != null)
        {
            murderWeapon.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Murder weapon reference is not set in the inspector.");
        }

        
    }

}
