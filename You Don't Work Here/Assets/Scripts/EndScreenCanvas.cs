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
        LossConditionTextMesh.text = LossHandler.LossText; 
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
