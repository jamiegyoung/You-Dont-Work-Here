using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopLight : MonoBehaviour
{

    [SerializeField]
    private BillPaymentSystem bps;  //Bill Payment System


    [SerializeField]
    private GameObject lowBattery;

   
    // Start is called before the first frame update
    void Start()
    {
        if (bps.electricityDaysDue < 3 || !DayTracker.instance || (DayTracker.instance && DayTracker.instance.currentDay == 0)) 
        {
           
            gameObject.SetActive(true);
            lowBattery.SetActive(false);
        }
        else
        {
            Debug.Log("here");
            gameObject.SetActive(false);
            lowBattery.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
