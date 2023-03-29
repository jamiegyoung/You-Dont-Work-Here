using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FailPanel : MonoBehaviour
{
    private Animator failAnim;
    [SerializeField] private TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        failAnim = GetComponent<Animator>();
    }

    public void PlayAnim(int mistakes)
    {
        if (mistakes == 1)
        {
            tmp.text = "Your lack of enthusiasm for the job has already affected the company's productivity, you have two more chances.";
        }
        else if (mistakes == 2)
        {
            tmp.text = "Your lack of enthusiasm for the job has already affected the company's productivity, you have one more chance. \n\nIf it happens again, your pay will be docked.";
        }
        else
        {
            tmp.text = "Your lack of enthusiasm for the job has severly affected the company's productivity, your pay has be docked.";
        }
        failAnim.SetTrigger("ShowFailPanel");
    }
}
