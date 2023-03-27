using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName="Money Objects/Bank Account")]
public class PlayerMoney : ScriptableObject
{
    [SerializeField]
    private float balance;


    /// <summary>
    /// Method <c>GetBalance</c> returns the players current bank balance.
    /// </summary>
    public float GetBalance()
    {
        return balance;
    }

    /// <summary>
    /// Method <c>Deposit</c> deposits a given value into the players current bank balance and returns the updated balance.
    /// </summary>
    /// <param name="value">Value to increment bank balance by.</param>
    public float Deposit(float value)
    {
        balance += value;
        return balance;
    }

    /// <summary>
    /// Method <c>Withdraw</c> withdraws a given value from the players current bank balance.
    /// </summary>
    /// <param name="value">Value to decrement bank balance by.</param>
    ///<returns> A boolean representing whether or not the withdrawal was succesful </returns>
    public bool Withdraw(float value)
    {
        if (balance >= value)
        {
            balance -= value;
            return true;
        }
        else
        {
            return false;
        }
    }
}