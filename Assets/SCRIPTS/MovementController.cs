using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;   
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;


public class MovementController : MonoBehaviour
{
    
    Rigidbody2D rb;

    [SerializeField] int speed;
    float speedMultiplier;

    bool btnPressed;
    private object speedMultipier;

    public int SpeedMultipier { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        updateSpeedMultiplier(GetSpeedMultipier());
        float targetSpeed = speed * speedMultiplier;

        rb.linearVelocity = new Vector2 (targetSpeed, rb.linearVelocity.y);
    }
    public void Move(InputAction.CallbackContext value)
    {
        if (value.started) 
        { 
            btnPressed = true;
           
        }
        else if (value.canceled) 
        {
            btnPressed = false; 
            
        }
    }

    private object GetSpeedMultipier()
    {
        return speedMultipier;
    }

    void updateSpeedMultiplier(object speedMultipier)
    {
        if (btnPressed && SpeedMultipier < 1) 
        {
            speedMultiplier += Time.deltaTime;
        }
       
    }
}

