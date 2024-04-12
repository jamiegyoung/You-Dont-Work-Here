using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseCanvas : MonoBehaviour
{

    public SceneLoader sceneLoader;
    public PauseController pauseController;

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    public void MainMenu()
    {
        sceneLoader.LoadLevel(SceneLoader.Level.MainMenu);
        if (DayTracker.instance != null)
        {
            DayTracker.instance = null;
        }

        if (EmployeeGenerator.instance != null)
        {
            EmployeeGenerator.instance = null;
        }
    }
    

    public void Resume()
    {
        pauseController.TogglePause();

    }

}
