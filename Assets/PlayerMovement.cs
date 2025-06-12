using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public Animator animator;    // Reference to the Animator component

    private Vector2 movement;    // Stores movement input

    void Update()
    {
        // Capture input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize movement to prevent faster diagonal movement
        movement = movement.normalized;

        // Update Animator Parameters
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetBool("IsMoving", movement != Vector2.zero);
    }

    void FixedUpdate()
    {
        // Move the player
        transform.position += new Vector3(movement.x, movement.y, 0) * moveSpeed * Time.fixedDeltaTime;
    }
}
