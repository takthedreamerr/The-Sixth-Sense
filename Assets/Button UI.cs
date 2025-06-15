using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongButton : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No next scene available");
            // Optional: Loop back to first scene
            // SceneManager.LoadScene(0);
        }
    }
}
