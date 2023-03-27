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
    public GameObject closeUpEmployee;
    public Animator acceptRejectButtonsAnim;
    private PlayableDirector walkInEmployeePlayable;
    private PlayableDirector acceptEmployeePlayable;
    private PlayableDirector rejectEmployeePlayable;
    //private PlayableDirector pd;
    public Image face;
    public Image eyes;
    public Image hair;
    public Image mouth;
    public Image glasses;
    private EmployeeGenerator employeeGenerator;
    private List<Employee> employeesToProcess;
    private Employee currentEmployee;
    private Animator closeUpAnim;
    public int mistakes;
    private bool accepted = false;
    private bool rejected = false;

    void Start()
    {
        mistakes = 0;
        employeeGenerator = EmployeeGenerator.instance;
        walkInEmployeePlayable = walkInEmployee.GetComponent<PlayableDirector>();
        acceptEmployeePlayable = acceptEmployee.GetComponent<PlayableDirector>();
        rejectEmployeePlayable = rejectEmployee.GetComponent<PlayableDirector>();
        walkInEmployee.SetActive(true);
        acceptEmployee.SetActive(false);
        rejectEmployee.SetActive(false);
        employeesToProcess = employeeGenerator.employees;
        closeUpAnim = closeUpEmployee.GetComponent<Animator>();
        closeUpEmployee.SetActive(false);
        StartCoroutine(ProcessEmployees());
    }

    public void SetAccepted(EmployeeOption option)
    {
        if (option.id != currentEmployee.id)
        {
            mistakes++;
        }
        accepted = true;
    }

    public void SetRejected()
    {
        if (employeeGenerator.employees.Find(e => e.id == currentEmployee.id) != null)
        {
            mistakes++;
        }
        rejected = true;
    }

    private IEnumerator ProcessEmployees()
    {
        while (employeesToProcess.Count > 0)
        {
            Debug.Log(employeesToProcess.Count);
            currentEmployee = employeesToProcess[UnityEngine.Random.Range(0, employeesToProcess.Count)];
            yield return PlayTimelineRoutine(walkInEmployee, walkInEmployeePlayable, PlayFaceAnimation(), 1);
            employeesToProcess.Remove(currentEmployee);
        }
    }

    private IEnumerator WaitForUserProcessing()
    {
        // https://answers.unity.com/questions/586609/waiting-for-input-via-coroutine.html
        ShowCloseUpEmployee();
        acceptRejectButtonsAnim.SetBool("ShowButtons", true);
        accepted = false;
        rejected = false;
        while (accepted == false && rejected == false)
        {
            yield return null;
        }
        acceptRejectButtonsAnim.SetBool("ShowButtons", false);
        HideCloseUpEmployee(accepted);
    }


    private void HideCloseUpEmployee(bool accepted)
    {
        if (accepted)
        {

        closeUpAnim.SetTrigger("accept");
        }else
        {
            closeUpAnim.SetTrigger("reject");
        }
    }

    private void ShowCloseUpEmployee()
    {
        eyes.sprite = currentEmployee.eyesSprite;
        hair.sprite = currentEmployee.hairSprite;
        hair.color = currentEmployee.hairColor;
        face.sprite = currentEmployee.face.faceSprite;
        face.color = currentEmployee.faceColor;
        if (currentEmployee.wearsGlasses)
        {
            glasses.color = new Color32(255, 255, 255, 255);
            glasses.sprite = currentEmployee.face.glassesSprite;
        }
        else
        {
            // Make the glasses transparent
            glasses.color = new Color32(0, 0, 0, 0);
        }
        mouth.sprite = currentEmployee.mouthSprite;
        closeUpEmployee.SetActive(true);
    }

    private IEnumerator PlayFaceAnimation()
    {
        yield return StartCoroutine(WaitForUserProcessing());
        acceptEmployee.SetActive(true);
        walkInEmployee.SetActive(false);
        yield return StartCoroutine(PlayTimelineRoutine(accepted ? acceptEmployee : rejectEmployee, accepted ? acceptEmployeePlayable : rejectEmployeePlayable));
        closeUpEmployee.SetActive(false);
    }

    private IEnumerator PlayTimelineRoutine(GameObject obj, PlayableDirector playable, IEnumerator onComplete, float timelineEndingOffset)
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
        yield return PlayTimelineRoutine(obj, playable, onComplete, 0);
    }

    private IEnumerator PlayTimelineRoutine(GameObject obj, PlayableDirector playable)
    {
        yield return PlayTimelineRoutine(obj, playable, null, 0);
    }

}
