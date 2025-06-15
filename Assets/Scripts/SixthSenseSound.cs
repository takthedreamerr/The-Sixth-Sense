using UnityEngine;
using System.Collections;

public class SixthSenseSound : MonoBehaviour
{
    [Header("References")]
    public Transform player;         // Reference to the player or camera
    public AudioSource symbolAudio;  // The symbol’s AudioSource

    [Header("Sound Settings")]
    public float maxDistance = 10f;  // Max distance where sound is still audible
    public float fadeOutDuration = 0.5f; // Time to fade out before destroy

    private void Start()
    {
        if (symbolAudio != null)
        {
            symbolAudio.loop = true;
            symbolAudio.Play();
        }
    }

    private void Update()
    {
        if (player == null || symbolAudio == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        // Volume scales down as distance increases
        float volume = Mathf.Clamp01(1 - (distance / maxDistance));
        symbolAudio.volume = volume;
    }

    // Optional: call this on click or external trigger
    public void StopAndDestroy()
    {
        if (symbolAudio != null)
            symbolAudio.Stop();

        Destroy(gameObject);
    }

    // Optional: smooth fade-out before destroying the object
    public void FadeOutAndDestroy()
    {
        StartCoroutine(FadeOutRoutine(fadeOutDuration));
    }

    private IEnumerator FadeOutRoutine(float duration)
    {
        if (symbolAudio == null)
        {
            Destroy(gameObject);
            yield break;
        }

        float startVolume = symbolAudio.volume;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            symbolAudio.volume = Mathf.Lerp(startVolume, 0f, elapsed / duration);
            yield return null;
        }

        symbolAudio.Stop();
        Destroy(gameObject);
    }

    // Optional: if object has collider and is directly clicked
    private void OnMouseDown()
    {
        FadeOutAndDestroy(); // Or use StopAndDestroy() for instant removal
    }
}

