using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenCanvas : MonoBehaviour
{

    public SceneLoader sceneLoader;
    [SerializeField] private TextMeshProUGUI LossConditionTextMesh;
    [SerializeField] private LossReason lossReason;
    [SerializeField] private TextMeshProUGUI dayCount;

    public void Start()
    {
        LossConditionTextMesh.text = lossReason.ToString();
        dayCount.text = "YOU LASTED " + DayTracker.instance.currentDay+" DAYS";
    }

    public void Restart()
    {
        Destroy(EmployeeGenerator.instance);
        EmployeeGenerator.instance = null;
        Destroy(DayTracker.instance);
        DayTracker.instance = null;
        sceneLoader.LoadLevel(SceneLoader.Level.MainMenu);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
