using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour, Interactable
{
    public bool IsInteractable => true;

    public DayTracker tracker;


    public void Interact(GameObject interactor)
    {
        tracker.IncrementDay();
        Debug.Log("Incremented Day to " + tracker.currentDay);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
