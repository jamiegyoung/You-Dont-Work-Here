using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class EmployeeHandler : MonoBehaviour
{
    public GameObject walkInEmployee;
    public GameObject acceptEmployee;
    public GameObject rejectEmployee;
    private PlayableDirector walkInEmployeePlayable;
    private PlayableDirector acceptEmployeePlayable;
    private PlayableDirector rejectEmployeePlayable;

    private PlayableDirector pd;

    // Start is called before the first frame update
    void Start()
    {
        walkInEmployeePlayable = walkInEmployee.GetComponent<PlayableDirector>();
        acceptEmployeePlayable = acceptEmployee.GetComponent<PlayableDirector>();
        rejectEmployeePlayable = rejectEmployee.GetComponent<PlayableDirector>();
        walkInEmployee.SetActive(true);
        acceptEmployee.SetActive(false);
        rejectEmployee.SetActive(false);
        StartCoroutine(PlayTimelineRoutine(walkInEmployee, walkInEmployeePlayable, PlayFaceAnimation));
    }

    private void PlayFaceAnimation()
    {
        //pd.playableAsset = acceptTimeline;
        //PlayTimelineRoutine(pd);
        //Debug.Log("hiiii");
        acceptEmployee.SetActive(true);
        walkInEmployee.SetActive(false);
        acceptEmployeePlayable.Play();
    }


    private IEnumerator PlayTimelineRoutine(GameObject obj, PlayableDirector playable, float timelineEndingOffset, Action onComplete)
    {
        Debug.Log("1");
        obj.SetActive(true);
        playable.Play();
        yield return new WaitForSeconds((float)playable.duration - timelineEndingOffset);
        if (onComplete != null) onComplete();
    }

    private IEnumerator PlayTimelineRoutine(GameObject obj, PlayableDirector playable, Action onComplete)
    {
        return PlayTimelineRoutine(obj, playable, 0, onComplete);
    }

    private IEnumerator PlayTimelineRoutine(GameObject obj, PlayableDirector playable)
    {
        return PlayTimelineRoutine(obj, playable, 0, null);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
