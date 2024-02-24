using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppNavigationTool : MonoBehaviour
{
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    public void ReLoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private bool isPaused = false;
    public void Pause()
    {
        isPaused = !isPaused;
        var timeScale = (isPaused == true) ? Time.timeScale = 0 : Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}