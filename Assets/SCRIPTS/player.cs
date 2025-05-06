using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class MOVEMENTS : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        //Check for WASD and Arrow Key inputs 
        if (Input.GetKey(KeyCode.W))
        { 
            moveDirection.y += 1;    
        }
        if (Input.GetKey(KeyCode.S)) 
        {
            moveDirection.y -= 1;    
        }
        if (Input.GetKey(KeyCode.A))
        { 
            moveDirection.x -= 1;    
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            moveDirection.x += 1;    
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.y += 1;  
        }
        if (Input.GetKey(KeyCode.DownArrow))
        { 
            moveDirection.y -= 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))    
        {
            moveDirection.x -= 1;
        }   
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x += 1;
        }
         

        // Move the player 
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

        


    }
}     

