using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1f;
    public float holdDuration = 1f;
    public GameObject gameplayRoot; // assign player or gameplay scripts root object

    void Start()
    {
        if (gameplayRoot != null)
            gameplayRoot.SetActive(false); // disable gameplay

        StartCoroutine(FadeSequence());
    }

    IEnumerator FadeSequence()
    {
        // Fade In
        yield return StartCoroutine(Fade(0f, 1f));

        // Hold full opacity
        yield return new WaitForSeconds(holdDuration);

        // Fade Out
        yield return StartCoroutine(Fade(1f, 0f));

        if (gameplayRoot != null)
            gameplayRoot.SetActive(true); // re-enable gameplay

        gameObject.SetActive(false); // optional: remove fade image after
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / fadeDuration);
            canvasGroup.alpha = alpha;
            yield return null;
        }

        canvasGroup.alpha = endAlpha;
    }
}

