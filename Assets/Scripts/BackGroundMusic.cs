using UnityEngine;
using UnityEngine.UI;

public class BackGroundMusic : MonoBehaviour
{
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    public Button musicButton;

    private static BackGroundMusic backgroundmusic;
    private AudioSource audioSource;
    private bool isMusicOn = true;

    void Awake()
    {
        if (backgroundmusic == null)
        {
            backgroundmusic = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Assign click listener
        musicButton.onClick.AddListener(ToggleMusic);

        UpdateButtonSprite();
    }

    void ToggleMusic()
    {
        isMusicOn = !isMusicOn;

        if (isMusicOn)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }

        UpdateButtonSprite();
    }

    void UpdateButtonSprite()
    {
        Image buttonImage = musicButton.GetComponent<Image>();
        buttonImage.sprite = isMusicOn ? musicOnSprite : musicOffSprite;
    }
}
