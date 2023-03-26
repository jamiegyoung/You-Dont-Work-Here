using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class EmployeeHandler : MonoBehaviour
{
    public GameObject employee;
    public TimelineAsset walkInTimeline;
    public TimelineAsset acceptTimeline;
    public TimelineAsset rejectTimeline;

    // Start is called before the first frame update
    void Start()
    {
        Employee tmp = EmployeeGenerator.employeeGeneratorInstance.employees[0];
        PlayableDirector a = employee.GetComponent<PlayableDirector>();
        a.playableAsset = walkInTimeline;
        Debug.Log("pog");
        StartCoroutine(PlayTimelineRoutine(a, 1, PlayFaceAnimation));
    }

    private void PlayFaceAnimation()
    {
        //PlayTimelineRoutine
        Debug.Log("hiiii");
    }


    private IEnumerator PlayTimelineRoutine(PlayableDirector playable, float timelineEndingOffset, Action onComplete)
    {
        playable.Play();
        yield return new WaitForSeconds((float)playable.duration - timelineEndingOffset);
        onComplete();
    }

    private IEnumerator PlayTimelineRoutine(PlayableDirector playable, Action onComplete)
    {
        PlayTimelineRoutine(playable, 0, PlayFaceAnimation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
