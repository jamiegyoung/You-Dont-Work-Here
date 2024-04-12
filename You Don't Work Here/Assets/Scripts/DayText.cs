using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayText : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }


    private void Update()
    {
        if (DayTracker.instance != null)
        {
            tmp.text = "Day " + DayTracker.instance.currentDay;
        }
    }
}
