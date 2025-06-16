using UnityEngine;


public class FireworkOnStart : MonoBehaviour
{
    private ParticleSystem fireworks;

    void Start()
    {
        fireworks = GetComponent<ParticleSystem>();
        if (fireworks != null)
        {
            fireworks.Play();
        }
    }
}
