using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /// Method <c>Withdraw</c> withdraws a given value from the players current bank balance and returns the updated balance.
    /// </summary>
    /// <param name="value">Value to decrement bank balance by.</param>
    public float Withdraw(float value)
    {
        balance -= value;
        return balance;
    }
}