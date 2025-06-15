using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wrong : MonoBehaviour 
{
    public void OpenLevel(int levelId)
    {
        SceneManager.LoadSceneAsync(4);

    }
}
