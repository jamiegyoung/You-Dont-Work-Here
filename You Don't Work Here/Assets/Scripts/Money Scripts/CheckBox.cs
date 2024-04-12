using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckBox : MonoBehaviour
{

    public bool clicked { get; private set; } =false;
    [SerializeField] private bool payButton;

    public TextMeshProUGUI text;
  

    public void OnClick()
    {
        if (clicked)
        {
            clicked = false;
            if (!payButton) //If checkbox uncheck
                text.text = "";
        }
        else
        {
            clicked = true;
            if (!payButton) //If checkbox check
                text.text = "X";
        }
    }
}
