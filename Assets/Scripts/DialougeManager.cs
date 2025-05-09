using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class DialougeManager : MonoBehaviour
{
    private Queue<string> sentenses;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentenses = new Queue<string>();
    }

    
}
