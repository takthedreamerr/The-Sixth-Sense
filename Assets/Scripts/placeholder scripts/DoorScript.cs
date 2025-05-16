using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class DoorScript : MonoBehaviour
{
    private Animator animator;
    private Collider2D doorCollider;

    [Header("Lighting")]
    public Light2D globalLight;
    public Light2D playerLight;

    [Header("Sixth Sense Symbols")]
    public GameObject[] sixthSenseSymbols;

    void Start()
    {
        animator = GetComponent<Animator>();
        doorCollider = GetComponent<Collider2D>();

        // Disable lights at start
        if (globalLight != null) globalLight.enabled = false;
        if (playerLight != null) playerLight.enabled = false;

        // Disable sixth sense symbols and their audio at start
        foreach (GameObject symbol in sixthSenseSymbols)
        {
            if (symbol != null)
            {
                symbol.SetActive(false); // Disables the GameObject and its AudioSource
            }
        }
    }

    public void OpenDoor()
    {
        animator.SetTrigger("Open");

        // Enable lights when door opens
        if (globalLight != null) globalLight.enabled = true;
        if (playerLight != null) playerLight.enabled = true;

        // Activate sixth sense symbols
        foreach (GameObject symbol in sixthSenseSymbols)
        {
            if (symbol != null)
            {
                symbol.SetActive(true); // Enables GameObject and AudioSource
            }
        }

        // Optional: disable door collider after a short delay
        StartCoroutine(DisableColliderAfterDelay(0.5f));
    }

    private IEnumerator DisableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        doorCollider.enabled = false;
    }
    public void DisableLights()
    {
        if (globalLight != null) globalLight.enabled = false;
        if (playerLight != null) playerLight.enabled = false;
    }
}
