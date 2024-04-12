using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightOffElectricity : MonoBehaviour
{

    [SerializeField] Light2D light2d;
    [SerializeField] BillPaymentSystem bps;
    // Start is called before the first frame update
    void Start()
    {

        if (bps.electricityDaysDue < 3)
        {

            light2d.enabled = true;
        }
        else
        {
            light2d.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
