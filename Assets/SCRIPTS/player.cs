using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEMENTS : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public Animator animator; // Drag your Animator here in the Inspector

    Vector2 movement;

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // Check for input (WASD or Arrow Keys)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            moveDirection.y += 1;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            moveDirection.y -= 1;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            moveDirection.x -= 1;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            moveDirection.x += 1;

        // Normalize movement
        moveDirection = moveDirection.normalized;

        // Move the player
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Update Animator Parameters
        animator.SetFloat("MoveX", moveDirection.x);
        animator.SetFloat("MoveY", moveDirection.y);
        animator.SetBool("IsMoving", moveDirection != Vector3.zero);

        // Optional: Store last direction for idle facing
        if (moveDirection != Vector3.zero)
        {
            animator.SetFloat("LastMoveX", moveDirection.x);
            animator.SetFloat("LastMoveY", moveDirection.y);
        }
    }
}
