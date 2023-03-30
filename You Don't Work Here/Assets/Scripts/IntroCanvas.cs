using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCanvas : MonoBehaviour
{
    public SceneLoader sceneLoader;

    // Start is called before the first frame update
    void OnEnable()
    {
        sceneLoader.LoadLevel(SceneLoader.Level.House);
    }
}
