using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTracker : MonoBehaviour
{
    public int currentDay = 0; // Default for now. Will be set later.
    public int finalDay = 6;
    public static DayTracker instance;
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void IncrementDay()
    {
        currentDay++;
        Debug.Log("Current day:" + currentDay);
    }
}