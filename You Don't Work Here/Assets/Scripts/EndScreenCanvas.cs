using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenCanvas : MonoBehaviour
{

    public SceneLoader sceneLoader;
    [SerializeField] private TextMeshProUGUI LossConditionTextMesh;
    [SerializeField] private LossReason lossReason;

    public void Start()
    {
        LossConditionTextMesh.text = lossReason.ToString();
    }

    public void Restart()
    {
        sceneLoader.LoadLevel(SceneLoader.Level.MainMenu);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
