using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DisplayBills : MonoBehaviour
{
    [SerializeField]
    private BillPaymentSystem bps;
    [SerializeField]
    private PlayerMoney player;
    [SerializeField] private GameObject[] checkBoxObjects;
    [SerializeField] private GameObject payButton;
    private bool display = false;


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
            float subtotal = 0;
            bool payGas = checkBoxObjects[0].GetComponent<CheckBox>().clicked;
            bool payElectricity = checkBoxObjects[1].GetComponent<CheckBox>().clicked;
            bool payFood = checkBoxObjects[2].GetComponent<CheckBox>().clicked;
            if (payGas) subtotal += gas;
            if (payElectricity) subtotal += electricity;
            if (payFood) subtotal += food;
            float balance = player.GetBalance() - subtotal;
            billText.GetComponent<TextMeshProUGUI>().text = "Check box to pay bill\n\n\nGas: £" + gas + ".00\n\nElectricity: £" + electricity 
                + ".00\n\nFood: £" + food + ".00\n\n\nTotal: £" + total + ".00\nCurrent Payment: £"+subtotal+".00\nCurrent Balance: £"+balance+".00";
            if(balance > 0)
            {
                payButton.SetActive (true);
            }
            else
            {
                payButton.SetActive (false);
            }
            if (payButton.GetComponent<CheckBox>().clicked)
            {
                bps.PayBills(new Bills(payGas, payFood, payElectricity));
                UpdateBills();
            }
        }
    }

    public void DisplayBill()
    {
        display = true;
        bps.IncreaseBills(1);
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
