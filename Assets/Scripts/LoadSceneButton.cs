using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

//Title: Create LEVEL MENU in Unity: UI Design & Level Locking/Unlocking System!
//Author: Rehope Games 
//Date:   27 May 2023
//Code Version: 1
//Avaibility: https://www.youtube.com/watch?v=2XQsKNHk1vk&t=1s

public class LoadSceneButton: MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(4);
    }
}

