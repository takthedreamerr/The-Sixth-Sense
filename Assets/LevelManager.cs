using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Title: How to Create a PAUSE MENU in Unity ! | UI Design Tutorial
//Author: Rehope Games 
//Date:  6 Jun 2023
//Code Version: 1
//Avaibility: https://www.youtube.com/watch?v=MNUYe0PWNNs&t=1s

public class LevelManager : MonoBehaviour
{
    public string sceneName;
    //start is called before first frame 

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    






}  
