using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{

    [SerializeField]
    private BillPaymentSystem bps;  //Bill Payment System

    [SerializeField] private GameObject[] itemsSelected;

    [SerializeField] private GameObject[] productTicks;

    [SerializeField] private TextMeshProUGUI[] remainingItems;

    [SerializeField] private TextMeshProUGUI balance;

    [SerializeField]
    private PlayerMoney player; //Players bank account

    [SerializeField] private GameObject payButton;

    [SerializeField] private ProductsLeft products;

    public SceneLoader sceneLoader;

    private float[] prices = new float[4] { 10f, 16f, 30f, 75f };

    private float subtotal = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        if(DayTracker.instance.currentDay == 1)
        {
            products.ResetValues();
        }
        products.decrementSupply();
        bps.PayEmployee();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < itemsSelected.Length; i++)
        {
            int count = products.GetCount((ProductsLeft.Products)i) ;
            if (count < 0) count = 0;
            bool bought = products.CheckBought((ProductsLeft.Products)i);
            if(count < 1 || bought)
            {
                itemsSelected[i].SetActive(false);
                productTicks[i].SetActive(true);
                remainingItems[i].text = count+" remaining";
            }
            else
            {
                productTicks[i].SetActive(false);
                itemsSelected[i].SetActive(true);
                remainingItems[i].text = count + " remaining";
            }
        }

        subtotal = 0;
            for (int i = 0; i < itemsSelected.Length; i++)
            {
                if (itemsSelected[i].GetComponent<CheckBox>().clicked && itemsSelected[i].activeSelf)
                {
                    subtotal += prices[i];
                }
            }

            balance.text = "Subtotal: £" + subtotal.ToString("0.00") + "\n\nBank Balance: £" + (player.GetBalance() - subtotal).ToString("0.00");

        if((player.GetBalance() - subtotal) < 0)
        {
            payButton.SetActive(false);
        }
        else
        {
            payButton.SetActive(true);
        }

        if (payButton.GetComponent<CheckBox>().clicked)
        {
            
            if (player.Withdraw(subtotal))
            {
                for (int i = 0; i < itemsSelected.Length; i++)
                {
                    if (itemsSelected[i].GetComponent<CheckBox>().clicked && itemsSelected[i].activeSelf)
                    {
                        products.buyProduct((ProductsLeft.Products)i);
                    }
                }
                sceneLoader.LoadLevel(SceneLoader.Level.BillPayment);
                return;
            }
        }
       
    }

  

}
