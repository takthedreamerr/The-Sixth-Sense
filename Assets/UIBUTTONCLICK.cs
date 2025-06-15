using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonClickSound : MonoBehaviour
{
    private static AudioSource sharedAudioSource;
    public AudioClip clickSound; // Assign your click sound in Inspector

    void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(PlayClickSound);

        // Reuse a global AudioSource so it persists across scenes
        if (sharedAudioSource == null)
        {
            GameObject audioObject = new GameObject("UI_ClickSound_Audio");
            DontDestroyOnLoad(audioObject);
            sharedAudioSource = audioObject.AddComponent<AudioSource>();
            sharedAudioSource.playOnAwake = false;
        }
    }

    void PlayClickSound()
    {
        if (clickSound != null && sharedAudioSource != null)
        {
            sharedAudioSource.PlayOneShot(clickSound);
        }
    }
}
