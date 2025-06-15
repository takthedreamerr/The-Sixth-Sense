using UnityEngine;

public class MOVEMENTS : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Animation")]
    public Animator animator;

    [Header("Audio")]
    private AudioSource footstepAudio;

    private Vector2 movement;

    void Start()
    {
        footstepAudio = GetComponent<AudioSource>();

        if (footstepAudio == null)
            Debug.LogWarning("No AudioSource found on the player!");
    }

    void Update()
    {
        HandleInput();
        MovePlayer();
        UpdateAnimation();
        HandleFootsteps();
    }

    void HandleInput()
    {
        movement = Vector2.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            movement.y += 1;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            movement.y -= 1;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            movement.x -= 1;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            movement.x += 1;

        movement = movement.normalized;
    }

    void MovePlayer()
    {
        transform.position += (Vector3)movement * moveSpeed * Time.deltaTime;
    }

    void UpdateAnimation()
    {
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetBool("IsMoving", movement != Vector2.zero);

        // Optional: Store last direction for idle state
        if (movement != Vector2.zero)
        {
            animator.SetFloat("LastMoveX", movement.x);
            animator.SetFloat("LastMoveY", movement.y);
        }
    }

    void HandleFootsteps()
    {
        if (movement != Vector2.zero)
        {
            if (!footstepAudio.isPlaying)
                footstepAudio.Play();
        }
        else
        {
            if (footstepAudio.isPlaying)
                footstepAudio.Stop();
        }
    }
}
