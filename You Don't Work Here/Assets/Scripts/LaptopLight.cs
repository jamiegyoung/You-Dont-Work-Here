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
        if(!DayTracker.instance || (DayTracker.instance && DayTracker.instance.currentDay == 0))
        {
            bps.RestartGame();
        }
        if (bps.electricityDaysDue < 3) 
        {
            
            lowBattery.SetActive(false);
            gameObject.SetActive(true);
        }
        else
        {
            lowBattery.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
