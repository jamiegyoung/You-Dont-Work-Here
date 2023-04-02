using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Loss Reason")]
public class LossReason : ScriptableObject
{
    public LossConditions lossReason;

    public new string ToString
    {
        get
        {
            switch (lossReason)
            {
                case LossConditions.Starvation:
                    return "AND EVENTUALLY PERISHED DUE TO STARVATION";
                case LossConditions.Frozen:
                    return "AND MET YOUR DEMISE BY FREEZING TO DEATH";
                default:
                    return "AND PASSED AWAY DUE TO AN UNKNOWN FORCE";
            }
        }
    }
}
