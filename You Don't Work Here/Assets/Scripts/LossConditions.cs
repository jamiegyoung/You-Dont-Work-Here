using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class LossConditions : MonoBehaviour
{
    public bool GameHasEnded { get; set; }
    public SceneLoader sceneLoader;
    public enum LossCondition
    {
        None,
        Starvation,
        Frozen,
    }

    public void EndGame()
    {
        if (!GameHasEnded)
        {
            GameHasEnded = true;
            sceneLoader.LoadLevel(SceneLoader.Level.EndScreen);
        }
    }
    
}

