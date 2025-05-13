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
    public GameObject[] sixthSenseSymbols;

    void Start()
    {
        animator = GetComponent<Animator>();
        doorCollider = GetComponent<Collider2D>();

        // Optional safety check: make sure lights start disabled
        if (globalLight != null) globalLight.enabled = false;
        if (playerLight != null) playerLight.enabled = false;
    }

    public void OpenDoor()
    {
        animator.SetTrigger("Open");

        // Enable vision-based lighting
        if (globalLight != null) globalLight.enabled = true;
        if (playerLight != null) playerLight.enabled = true;

        foreach (GameObject symbol in sixthSenseSymbols)
        {
            symbol.SetActive(true); // If you had them inactive before
        }

        // Optional: disable collider after short delay
        StartCoroutine(DisableColliderAfterDelay(0.5f));
    }

    private IEnumerator DisableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        doorCollider.enabled = false;
    }

}


