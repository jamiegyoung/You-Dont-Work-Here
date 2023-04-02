using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCanvas : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private SceneLoader.Level level;
    // Start is called before the first frame update
    void OnEnable()
    {
        sceneLoader.LoadLevel(level);
    }
}
