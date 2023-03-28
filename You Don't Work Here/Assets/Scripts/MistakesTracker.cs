using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mistake Tracker")]
public class MistakesTracker : ScriptableObject
{
    public int mistakes { get; private set; } = 0;

    public void ResetMistakes()
    {
        mistakes = 0;
    }

    public void incrementMistakes()
    {
        mistakes++;
    }

}
