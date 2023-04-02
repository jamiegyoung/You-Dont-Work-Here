using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenCanvas : MonoBehaviour
{

    public SceneLoader sceneLoader;
    [SerializeField] private TextMeshProUGUI LossConditionTextMesh;

    public void Start()
    {
        switch (LossHandler.LossCondition)
        {
            case LossHandler.LossConditions.Starvation:
                LossConditionTextMesh.text = "You starved to death";
                break;
            case LossHandler.LossConditions.Frozen:
                LossConditionTextMesh.text = "You froze to death";
                break;
            
        }
    }


    public void Restart()
    {
        sceneLoader.LoadLevel(SceneLoader.Level.House);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
