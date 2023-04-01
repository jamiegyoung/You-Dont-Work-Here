using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenCanvas : MonoBehaviour
{

    public SceneLoader sceneLoader;
    [SerializeField] private TextMeshProUGUI LossConditionTextMesh;
    [SerializeField] private LossConditions.LossCondition LossReason;
    public void Start()
    {
        switch (LossReason)
        {
            case LossConditions.LossCondition.Frozen:
                LossConditionTextMesh.text = "You froze to death";
                break;
            case LossConditions.LossCondition.Starvation:
                LossConditionTextMesh.text = "You starved to death";
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
