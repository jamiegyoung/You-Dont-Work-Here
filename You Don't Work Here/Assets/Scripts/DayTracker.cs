using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTracker : MonoBehaviour
{

    public int currentDay = 0; // Default for now. Will be set later.

    public DayTime Time { get; set; }
    public int FinalDay = 10;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void IncrementDay()
    {
        if(currentDay > FinalDay)
        {

            throw new NotImplementedException();
            return;
        }

        currentDay++;
        Time = DayTime.Day;

    }

   public void IncrementTime()
    {

        if(Time == DayTime.Night)
        {
            IncrementDay();
        }
        else
        {
            Time = DayTime.Night;
        }

    }
    

}
public enum DayTime
{
    Day,
    Night
}
