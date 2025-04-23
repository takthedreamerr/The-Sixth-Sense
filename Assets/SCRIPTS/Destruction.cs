using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("DestrucCol"));
        {
            Destroy(collision.gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("DestrucTrig"));
        {
            Destroy(other.gameObject); 
        }
    }
} 
