using UnityEngine;

public class SixthSenseSound : MonoBehaviour
{
    public Transform player;         
    public AudioSource symbolAudio;  
    public float maxDistance = 10f;  

    private void Start()
    {
        if (symbolAudio != null) symbolAudio.Play();
    }

    private void Update()
    {
        if (player == null || symbolAudio == null) return;

        float distance = Vector3.Distance(player.position, transform.position);
        float volume = Mathf.Clamp01(1 - (distance / maxDistance));
        symbolAudio.volume = volume;
    }

    private void OnMouseDown()
    {
        
        if (symbolAudio != null)
        {
            symbolAudio.Stop(); 
        }

        
    }
}


