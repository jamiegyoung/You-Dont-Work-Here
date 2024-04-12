
using System;
public class Bills
{
    //Variables to hold the price of each bill
    public float gasPrice { get; private set; }
    public float foodPrice { get; private set; }
    public float electricityPrice { get; private set; }

    //Variables to state whether each type of bil should be paid
    public bool payGas { get; private set; }
    public bool payFood { get; private set; }
    public bool payElectricity { get; private set; }

    /// <summary>
    /// Constructor method <c>Bills</c> takes in 3 floats representing the price of each bill.
    /// </summary>
    public Bills(float gasPrice, float foodPrice, float electricityPrice)
    {
        this.gasPrice = gasPrice;
        this.foodPrice = foodPrice;
        this.electricityPrice = electricityPrice;
    }

    /// <summary>
    /// Constructor method <c>Bills</c> takes in 3 bools representing whether each bill should be paid.
    /// </summary>
    /// <param name="payGas">Bool representing whether the gas bill sould be paid.</param>
    /// <param name="payFood">Bool representing whether the food bill sould be paid.</param>
    /// <param name="payElectricity">Bool representing whether the electricity bill sould be paid.</param>
    public Bills(bool payGas, bool payFood, bool payElectricity)
    {
        this.payGas = payGas;
        this.payFood = payFood;
        this.payElectricity = payElectricity;
    }
}