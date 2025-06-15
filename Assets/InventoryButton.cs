 using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class InventoryItemButton : MonoBehaviour, IPointerClickHandler
{
    public ParticleSystem clickParticleEffect;
    private static List<ParticleSystem> particlePool = new List<ParticleSystem>();

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayParticleEffect();
        Debug.Log("Item clicked: " + gameObject.name);
    }

    private void PlayParticleEffect()
    {
        if (clickParticleEffect == null) return;

        ParticleSystem availableParticle = null;

        // Check pool for available particle system
        foreach (var ps in particlePool)
        {
            if (!ps.isPlaying)
            {
                availableParticle = ps;
                break;
            }
        }

        // If none available, create new one
        if (availableParticle == null)
        {
            availableParticle = Instantiate(clickParticleEffect, transform);
            particlePool.Add(availableParticle);
            
            // UI Particle Configuration
            var main = availableParticle.main;
            main.scalingMode = ParticleSystemScalingMode.Hierarchy; // Important for UI
            availableParticle.transform.localPosition = Vector3.zero;
        }

        // Reset and play
        availableParticle.transform.position = transform.position;
        availableParticle.Play();
    }
}