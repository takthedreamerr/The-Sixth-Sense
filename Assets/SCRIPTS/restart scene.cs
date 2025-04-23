using UnityEngine;
using UnityEngine.SceneManagement;

public class restartscene : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}