using System.Collections;
using UnityEngine;

public class SoundExamples : MonoBehaviour
{

    public AudioClip[] Clips;
    private AudioSource audioSource;
    public ButtonSoundType soundType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public enum ButtonSoundType
    {
        background,
        click,
        footsteps,
    }


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerSound(ButtonSoundType soundType)
    {
        switch (soundType)
       {
           case ButtonSoundType.background:
                audioSource.PlayOneShot(Clips[0]);
                break;


            case ButtonSoundType.click:
                audioSource.PlayOneShot(Clips[1]);
                break;

            case ButtonSoundType.footsteps:
                audioSource.PlayOneShot(Clips[2]);
                break;
       }   


    }


    public void PlayAssignedSound()
    {
        PlayerSound(soundType);
    }
   
}



  
