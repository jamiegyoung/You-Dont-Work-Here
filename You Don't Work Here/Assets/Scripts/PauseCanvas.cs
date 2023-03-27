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
        sceneLoader.LoadLevel(SceneLoader.Level.Menu);
    }
    

    public void Resume()
    {
        pauseController.TogglePause();

    }

}
