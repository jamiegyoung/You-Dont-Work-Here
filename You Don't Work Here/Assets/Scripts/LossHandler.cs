using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class LossHandler : MonoBehaviour
{
    public bool GameHasEnded { get; set; } = false;
    public SceneLoader sceneLoader;

    public enum LossConditions
    {
        Starvation,
        Frozen,
    }

    public static LossConditions LossCondition;
    

    public void EndGame(int LossReason)
    {
        if (!GameHasEnded)
        {
            switch (LossReason)
            {
                case (int) LossConditions.Starvation:
                    GameHasEnded = true;
                    sceneLoader.LoadLevel(SceneLoader.Level.EndScreen);
                    break;
                case (int) LossConditions.Frozen:
                    GameHasEnded = true;
                    LossCondition++;
                    sceneLoader.LoadLevel(SceneLoader.Level.EndScreen);
                    break;
                default:
                    Debug.Log("Invalid Loss Condition. Please pick 0 for Starvation or 1 for Frozen");
                    break;
            }
        }
    }
    
}

