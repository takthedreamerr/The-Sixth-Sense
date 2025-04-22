using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelObjective : MonoBehaviour
{
    public void OpenScene(int SceneId)
    {
        SceneManager.LoadSceneAsync(2);

    }
}