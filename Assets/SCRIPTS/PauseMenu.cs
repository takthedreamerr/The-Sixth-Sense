
using UnityEngine;
using UnityEngine.SceneManagement;

//Title: How to Create a PAUSE MENU in Unity ! | UI Design Tutorial
//Author: Rehope Games 
//Date:  6 Jun 2023
//Code Version: 1
//Avaibility: https://www.youtube.com/watch?v=MNUYe0PWNNs&t=1s

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void Resume () 
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

    }

    public void Restart()
    { 
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}
