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

    [Header("Audio")]
    public AudioSource doorOpenSound;

    [Header("Camera")]
    public Transform mainCamera;       // Assign the Main Camera transform here
    public float panDuration = 2f;     // Time to pan to the door
    public float cameraHoldTime = 1f;  // Time to stay at the door before returning

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
                symbol.SetActive(false);
            }
        }
    }

    public void OpenDoor()
    {
        animator.SetTrigger("Open");

        // Play door sound
        if (doorOpenSound != null)
            doorOpenSound.Play();

        // Enable lights
        if (globalLight != null) globalLight.enabled = true;
        if (playerLight != null) playerLight.enabled = true;

        // Activate sixth sense symbols
        foreach (GameObject symbol in sixthSenseSymbols)
        {
            if (symbol != null)
                symbol.SetActive(true);
        }

        // Start camera pan
        if (mainCamera != null)
        {
            StartCoroutine(PanToDoorAndBack());
        }

        // Disable door collider after short delay
        StartCoroutine(DisableColliderAfterDelay(0.5f));
    }

    private IEnumerator DisableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (doorCollider != null)
            doorCollider.enabled = false;
    }

    public void DisableLights()
    {
        if (globalLight != null) globalLight.enabled = false;
        if (playerLight != null) playerLight.enabled = false;
    }

    private IEnumerator PanToDoorAndBack()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Transform cam = mainCamera;

        Vector3 originalPosition = cam.position;
        Transform originalParent = cam.parent;

        // Detach camera from player
        cam.parent = null;

        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, originalPosition.z);
        float elapsed = 0f;

        while (elapsed < panDuration)
        {
            cam.position = Vector3.Lerp(originalPosition, targetPosition, elapsed / panDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        cam.position = targetPosition;

        // Pause at the door
        yield return new WaitForSeconds(cameraHoldTime);

        // Pan back to player
        elapsed = 0f;
        Vector3 returnPosition = new Vector3(player.position.x, player.position.y, originalPosition.z);

        while (elapsed < panDuration)
        {
            cam.position = Vector3.Lerp(targetPosition, returnPosition, elapsed / panDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        cam.position = returnPosition;

        // Re-parent camera to player
        cam.parent = originalParent;
    }
}
