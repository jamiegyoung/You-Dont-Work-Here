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
    [SerializeField] private GameObject mugger;
    [SerializeField] private PlayerMoney playerMoney;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        pd = GetComponent<PlayableDirector>();
        if (DayTracker.instance.currentDay == 1)
        {
            mugger.SetActive(true);
            bc.enabled = true;
        }
        else
        {
            mugger.SetActive(false);
            bc.enabled = false;
        }
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
        playerMoney.Withdraw(playerMoney.GetBalance());
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
