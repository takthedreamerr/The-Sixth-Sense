using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator animator;
    private Collider2D doorCollider;

    void Start()
    {
        animator = GetComponent<Animator>();
        doorCollider = GetComponent<Collider2D>();
    }

    public void OpenDoor()
    {
        animator.SetTrigger("Open");

        // Optional: disable collider after short delay
        StartCoroutine(DisableColliderAfterDelay(0.5f));
    }

    private System.Collections.IEnumerator DisableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        doorCollider.enabled = false;
    }
}


