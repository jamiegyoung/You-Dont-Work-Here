using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckBox : MonoBehaviour
{

    public bool clicked { get; private set; } =false;
    [SerializeField] private bool payButton;

    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (clicked)
        {
            clicked = false;
            if (!payButton) 
                text.text = "";
        }
        else
        {
            clicked = true;
            if (!payButton)
                text.text = "X";
        }
    }
}
