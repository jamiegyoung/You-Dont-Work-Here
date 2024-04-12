using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PayBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI payBox;
    [SerializeField] MistakesTracker mistakes;

    private int pay;
    // Start is called before the first frame update
    void Start()
    {
        pay = 40;
        payBox.text = "£" + pay;
        payBox.color = new Color(0f, 0.5f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (mistakes.mistakes > 1)
        {
            int currentPay = 40 - ((mistakes.mistakes-2) * 20);
            if (currentPay != pay)
            {
                pay = currentPay;
                if (pay < 0)
                {
                    payBox.text = "- £" + (-pay);
                    payBox.color = new Color(0.75f, 0f, 0f, 1f);
                }
                else if (pay == 0)
                {
                    payBox.text = "£" + pay;
                    payBox.color = new Color(0.9f, 0.5f, 0f, 1f);
                }
                else
                {
                    payBox.text = "£" + pay;
                }

            }
        }
    }
}
