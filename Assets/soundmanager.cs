using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    [Header("UI Settings")]
    public Button soundToggleButton;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    [Header("Audio Sources to Toggle")]
    public List<AudioSource> targetAudioSources; // Drag any AudioSource component here (UI or GameObject)

    private static SoundManager instance;
    private bool isSoundOn = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (soundToggleButton != null)
            soundToggleButton.onClick.AddListener(ToggleSound);

        ApplySoundState();
        UpdateButtonSprite();
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        ApplySoundState();
        UpdateButtonSprite();
    }

    private void ApplySoundState()
    {
        foreach (AudioSource source in targetAudioSources)
        {
            if (source != null)
                source.mute = !isSoundOn;
        }
    }

    private void UpdateButtonSprite()
    {
        if (soundToggleButton != null)
        {
            Image buttonImage = soundToggleButton.GetComponent<Image>();
            if (buttonImage != null)
                buttonImage.sprite = isSoundOn ? soundOnSprite : soundOffSprite;
        }
    }
}
