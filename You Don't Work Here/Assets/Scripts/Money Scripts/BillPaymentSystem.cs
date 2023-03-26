using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BillPaymentSystem : ScriptableObject
{
    [SerializeField]
    private PlayerMoney player;

    //Initialise costings
    [Range(1f, 100f)]
    private float electricityCost = 20f;

    [Range(1f, 100f)]
    private float gasCost = 25f;

    [Range(1f, 10f)]
    private float increaseCost = 1.25f;

    [Range(1f, 100f)]
    private float foodCost = 20f;

    [Range(1f, 500f)]
    private float boilerFixCost = 100f;


    //Initialise bill totals
    private float electricityBill = 0;
    private float gasBill = 0;
    private float foodBill = 0;

    //Ininitalise boiler state
    private bool boilerBroken = false;



    /// <summary>
    /// Method <c>IncreaseBills</c> increases the value of the bills due by the calculated amount for that day.
    /// </summary>
    /// <param name="day">An integer representing the current day.</param>
    public void IncreaseBills(int day)
    {
        electricityBill += CalculateBill(electricityBill, day);
        gasBill += CalculateBill(gasCost, day);
        foodBill += foodCost;
    }


    /// <summary>
    /// Method <c>CalculateBill</c> calculates and returns the single day cost of a given utility's bill.
    /// </summary>
    /// <param name="cost">The initial single day cost of the given utility.</param>
    /// <param name="day">An integer representing the current day.</param>
    private float CalculateBill(float cost, int day)
    {
        return (float)Math.Round((cost * Math.Pow(increaseCost, day)), 2);
    }


    /// <summary>
    /// Method <c>GetBills</c> returns a Bills object which contains the 3 bill costs.
    /// </summary>

    public Bills GetBills()
    {
        return new Bills(gasBill, foodBill, electricityBill);

    }

    /// <summary>
    /// Method <c>PayBills</c> takes in a Bills object containing 3 boolean, representing whether or not the electricity, gas and food bill is to be paid.
    /// If bank balance can afford to pay selected bills, then the money will be withdrawn and bills set to £0.
    /// </summary>
    /// <param name="bills">Bills object with 3 bools representing whether each bill should be paid</param>
    public bool PayBills(Bills bills)
    {
        float total = 0;
        if (bills.payElectricity)
            total += electricityBill;
        if (bills.payGas)
            total += gasBill;
        if (bills.payFood)
            total += foodBill;


        if (player.Withdraw(total))
        {
            if (bills.payElectricity)
                electricityBill = 0;
            if (bills.payGas)
                gasBill = 0;
            if (bills.payFood)
                foodBill = 0;
            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// Method <c>BreakBoiler</c> sets the state of the boiler to 'broken'
    /// </summary>
    public void BreakBoiler()
    {
        boilerBroken = true;
    }


    /// <summary>
    /// Method <c>FixBoiler</c> sets the state of the boiler to 'fixed' and withdraws the cost if the player has enough money to pay for it in their account.
    /// </summary>
    public bool FixBoiler()
    {
        if (player.Withdraw(boilerFixCost))
        {
            boilerBroken = false;
            return true;
        }
        return false;
    }
}