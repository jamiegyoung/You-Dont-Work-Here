using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class EmployeeHandler : MonoBehaviour
{
    public GameObject walkInEmployee;
    public GameObject acceptEmployee;
    public GameObject rejectEmployee;
    private PlayableDirector walkInEmployeePlayable;
    private PlayableDirector acceptEmployeePlayable;
    private PlayableDirector rejectEmployeePlayable;
    private PlayableDirector pd;
    public Image face;
    public Image eyes;
    public Image hair;
    public Image mouth;
    public Image glasses;
    private EmployeeGenerator employeeGenerator;
    private List<Employee> employeesToProcess;
    private Employee currentEmployee;

    void Start()
    {
        employeeGenerator = EmployeeGenerator.instance;
        walkInEmployeePlayable = walkInEmployee.GetComponent<PlayableDirector>();
        acceptEmployeePlayable = acceptEmployee.GetComponent<PlayableDirector>();
        rejectEmployeePlayable = rejectEmployee.GetComponent<PlayableDirector>();
        walkInEmployee.SetActive(true);
        acceptEmployee.SetActive(false);
        rejectEmployee.SetActive(false);
        employeesToProcess = employeeGenerator.employees;
        StartCoroutine(ProcessEmployees());

    }

    private IEnumerator ProcessEmployees()
    {
        while (employeesToProcess.Count > 0)
        {
            Debug.Log(employeesToProcess.Count);
            currentEmployee = employeesToProcess[UnityEngine.Random.Range(0, employeesToProcess.Count)];
            yield return PlayTimelineRoutine(walkInEmployee, walkInEmployeePlayable, PlayFaceAnimation());
            employeesToProcess.Remove(currentEmployee);
        }

    }

    private IEnumerator PlayFaceAnimation()
    {
        //pd.playableAsset = acceptTimeline;
        //PlayTimelineRoutine(pd);
        //Debug.Log("hiiii");
        acceptEmployee.SetActive(true);
        walkInEmployee.SetActive(false);
        yield return StartCoroutine(PlayTimelineRoutine(acceptEmployee, acceptEmployeePlayable));
    }

    private IEnumerator PlayTimelineRoutine(GameObject obj, PlayableDirector playable, float timelineEndingOffset, IEnumerator onComplete)
    {
        obj.SetActive(true);
        playable.Play();
        yield return new WaitForSeconds((float)playable.duration - timelineEndingOffset);
        if (onComplete != null)
        {
            yield return onComplete;
        }
    }

    private IEnumerator PlayTimelineRoutine(GameObject obj, PlayableDirector playable, IEnumerator onComplete)
    {
        yield return PlayTimelineRoutine(obj, playable, 0, onComplete);
    }

    private IEnumerator PlayTimelineRoutine(GameObject obj, PlayableDirector playable)
    {
        yield return PlayTimelineRoutine(obj, playable, 0, null);
    }

}
