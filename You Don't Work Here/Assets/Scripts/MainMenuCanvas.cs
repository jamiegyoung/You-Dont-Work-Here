using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    public SceneLoader sceneLoader;
    // Start is called before the first frame update
    public void play()
    {
        sceneLoader.LoadLevel(SceneLoader.Level.Intro);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
