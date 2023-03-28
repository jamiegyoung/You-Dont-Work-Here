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
    private bool display = false;

    // Current bill values
    private float gas;
    private float electricity;
    private float food;
    private float total;


    GameObject checkBoxes;
    GameObject billText;
    // Start is called before the first frame update
    void Start()
    {
        checkBoxes = GameObject.FindWithTag("CheckBoxes");
        billText = GameObject.FindWithTag("BillText");
        checkBoxes.SetActive(false);
        billText.SetActive(false);
        payButton.SetActive(false);
        bps.RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(display)
        {
            // Get which bills the user has selected to pay
            bool payGas = checkBoxObjects[0].GetComponent<CheckBox>().clicked;
            bool payElectricity = checkBoxObjects[1].GetComponent<CheckBox>().clicked;
            bool payFood = checkBoxObjects[2].GetComponent<CheckBox>().clicked;
            
            //Calculate current subtotal for the bills selected to be paid
            float subtotal = 0;
            if (payGas) subtotal += gas;
            if (payElectricity) subtotal += electricity;
            if (payFood) subtotal += food;
            float balance = player.GetBalance() - subtotal;

            //Update user interface with new totals
            billText.GetComponent<TextMeshProUGUI>().text = "Check box to pay bill\n\n\nGas: £" + gas + ".00\n\nElectricity: £" + electricity 
                + ".00\n\nFood: £" + food + ".00\n\n\nTotal: £" + total + ".00\nCurrent Payment: £"+subtotal+".00\nCurrent Balance: £"+balance+".00";
            
            //If the users balance after the bills selected are withdrawn then display pay button
            if(balance > 0)
            {
                payButton.SetActive (true);
            }
            else
            {
                payButton.SetActive (false);
            }

            // If pay button is clicked, pay the selected bills and update the bill totals
            if (payButton.GetComponent<CheckBox>().clicked)
            {
                bps.PayBills(new Bills(payGas, payFood, payElectricity));
                UpdateBills();
                sceneLoader.LoadLevel(SceneLoader.Level.House);
            }
        }
    }
    /// <summary>
    /// Method <c>DisplayBill</c> displays the current bill payment screen
    /// </summary>
    public void DisplayBill()
    {
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
