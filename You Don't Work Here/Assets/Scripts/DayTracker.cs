using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTracker : MonoBehaviour
{
    public int currentDay = 0; // Default for now. Will be set later.
    public int FinalDay = 10;
    public static DayTracker instance;
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void IncrementDay()
    {
        if (currentDay > FinalDay)
        {

            throw new NotImplementedException();
            return;
        }

        currentDay++;
    }
}