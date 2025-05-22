using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Title: Player
//Author: Andy
//Date accessed: 19 May 
//Code Version: 1
//Avaibility: Download Week 6 - Conditional Statements, Switch Statements & Player Input.pdf (771 KB)


public class MOVEMENTS : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public Animator animator; 

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

        
        moveDirection = moveDirection.normalized;

        
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

      
        animator.SetFloat("MoveX", moveDirection.x);
        animator.SetFloat("MoveY", moveDirection.y);
        animator.SetBool("IsMoving", moveDirection != Vector3.zero);

       
        {
           // animator.SetFloat("LastMoveX", moveDirection.x);
            //animator.SetFloat("LastMoveY", moveDirection.y);
        }

        
    }


}
