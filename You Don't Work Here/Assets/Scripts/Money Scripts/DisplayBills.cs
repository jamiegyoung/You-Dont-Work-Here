using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DisplayBills : MonoBehaviour
{
    [SerializeField]
    private BillPaymentSystem bps;  //Bill Payment System
    [SerializeField]
    private PlayerMoney player; //Players bank account
    [SerializeField] private GameObject[] checkBoxObjects;  //Array of the checkboxes on the pay bill screen
    [SerializeField] private GameObject payButton;  // Gameobject for the oay button
    [SerializeField] private SceneLoader sceneLoader;

    [SerializeField] private TextMeshProUGUI hungerOutput;
    [SerializeField] private TextMeshProUGUI tempOutput;

    private Color[] statusColors = new Color[3] ;
    private string[] hungerStatus = new string[3] { "Full", "Hungry", "Starving" };
    private string[] tempStatus = new string[3] { "Warm", "Cold", "Freezing" };
    private bool display = false;

    // Current bill values
    private float gas;
    private float electricity;
    private float food;
    private float total;
    private bool payGas;
    private bool payFood;
    private bool payElectricity;

    GameObject checkBoxes;
    GameObject billText;
    // Start is called before the first frame update
    void Start()
    {
        statusColors[0] = new Color(0f,0.65f,0f,1f);
        statusColors[1] = new Color(0.83f,0.53f,0f,1f);
        statusColors[2] = new Color(0.8f, 0f, 0f, 1f);
        payFood = false;
        payGas = false;
        payElectricity = false;
        checkBoxes = GameObject.FindWithTag("CheckBoxes");
        billText = GameObject.FindWithTag("BillText");
        checkBoxes.SetActive(false);
        billText.SetActive(false);
        payButton.SetActive(false);
        if(DayTracker.instance.currentDay == 0)
            bps.RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (display)
        {
            // Get which bills the user has selected to pay
            payGas = checkBoxObjects[0].GetComponent<CheckBox>().clicked;
            payElectricity = checkBoxObjects[1].GetComponent<CheckBox>().clicked;
            payFood = checkBoxObjects[2].GetComponent<CheckBox>().clicked;

            //Calculate current subtotal for the bills selected to be paid
            float subtotal = 0;
            if (payGas) subtotal += gas;
            if (payElectricity) subtotal += electricity;
            if (payFood) subtotal += food;
            float balance = player.GetBalance() - subtotal;

            //Update user interface with new totals
            billText.GetComponent<TextMeshProUGUI>().text = "Check box to pay bill\n\n\nGas: £" + gas.ToString("0.00") + "\n\nElectricity: £" + electricity.ToString("0.00")
                + "\n\nFood: £" + food.ToString("0.00") + "\n\n\nTotal: £" + total.ToString("0.00") + "\nCurrent Payment: £" + subtotal.ToString("0.00") + "\nCurrent Balance: £" + balance.ToString("0.00");

            //If the users balance after the bills selected are withdrawn then display pay button
            if (balance > 0)
            {
                payButton.SetActive(true);
            }
            else
            {
                payButton.SetActive(false);
            }
        }
    }

    public void PayBill()
    {
        bps.PayBills(new Bills(payGas, payFood, payElectricity));
        hungerOutput.text = "";
        tempOutput.text = "";
        UpdateBills();
        DayTracker.instance.IncrementDay();
        sceneLoader.LoadLevel(SceneLoader.Level.House);
    }
    /// <summary>
    /// Method <c>DisplayBill</c> displays the current bill payment screen
    /// </summary>
    public void DisplayBill()
    {
        hungerOutput.text = hungerStatus[bps.foodDaysDue];
        hungerOutput.color = statusColors[bps.foodDaysDue];
        tempOutput.text = tempStatus[bps.gasDaysDue];
        tempOutput.color = statusColors[bps.gasDaysDue ];
        Debug.Log("Displaying Bill");
        Debug.Log("Food:" + bps.foodDaysDue + "  Gas:" + bps.gasDaysDue);
        bps.PayEmployee();
        display = true;
        bps.IncreaseBills(DayTracker.instance.currentDay);
        UpdateBills();
        billText.SetActive(true);
        checkBoxes.SetActive(true);
    }


    private void UpdateBills()
    {
        gas = bps.GetBills().gasPrice;
        electricity = bps.GetBills().electricityPrice;
        food = bps.GetBills().foodPrice;
        total = gas + electricity + food;
    }
}
