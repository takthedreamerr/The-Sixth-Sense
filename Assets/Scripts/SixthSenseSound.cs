using UnityEngine;

public class SixthSenseSound : MonoBehaviour
{
    public Transform player;         // Reference to the player or camera
    public AudioSource symbolAudio;  // The symbol’s AudioSource
    public float maxDistance = 10f;  // Max distance where sound is still audible

    private void Start()
    {
        if (symbolAudio != null) symbolAudio.Play();
    }

    void Update()
    {
        if (player == null || symbolAudio == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        // Invert the distance into volume
        float volume = Mathf.Clamp01(1 - (distance / maxDistance));
        symbolAudio.volume = volume;
    }
}

