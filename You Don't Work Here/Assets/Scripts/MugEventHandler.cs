using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MugEventHandler : MonoBehaviour
{

    private BoxCollider2D bc;
    private PlayableDirector pd;
    [SerializeField] private LossReason lossReason;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private PlayableDirector deathTimeline;
    [SerializeField] private PlayableDirector restOfMugTimeline;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        pd = GetComponent<PlayableDirector>();
        //if (DayTracker.instance.currentDay == 1)
        //{
        bc.enabled = true;
        //}
        //else
        //{
        //    bc.enabled = false;
        //}
        pd.enabled = true;
        deathTimeline.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            pd.Play();
        }
    }

    public void Accept()
    {
        restOfMugTimeline.enabled = true;
        pd.Stop();
        restOfMugTimeline.Play();
        bc.enabled = false;
    }

    public void Reject()
    {
        lossReason.lossReason = LossConditions.Stabbed;
        deathTimeline.enabled = true;
        pd.Stop();
        deathTimeline.Play();
    }
}
