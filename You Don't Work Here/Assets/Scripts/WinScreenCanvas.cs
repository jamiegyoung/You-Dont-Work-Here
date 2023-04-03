using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScreenCanvas : MonoBehaviour
{

    public SceneLoader sceneLoader;
    [SerializeField] private TextMeshProUGUI BrotherHappinessText, FatherHappinessText, MotherHappinessText;
    [SerializeField] private ProductsLeft products;


    void Start()
    {
        if (products.boughtFlowers && products.boughtWine)
        {
            MotherHappinessText.text = "YOUR MOTHER IS VERY PLEASED WITH YOU,";
        }
        else if ((!products.boughtFlowers && products.boughtWine) || (products.boughtFlowers && !products.boughtWine))
        {
            MotherHappinessText.text = "YOUR MOTHER IS ALRIGHT WITH YOUR EXISTENCE,";
        }
        else
        {
            MotherHappinessText.text = "YOUR MOTHER STILL HATES YOU,";
        }

        if (products.boughtWatch)
        {
            FatherHappinessText.text = "YOUR FATHER IS VERY PLEASED WITH YOU,";
        }
        else
        {
            FatherHappinessText.text = "YOUR FATHER STILL HATES YOU,";
        }

        if (products.boughtHeadphones)
        {
            BrotherHappinessText.text = "AND YOUR BROTHER IS VERY PLEASED WITH YOU";
        }
        else
        {
            BrotherHappinessText.text = "AND YOUR BROTHER STILL HATES YOU";
        }
    }


    public void Restart()
    {
        Destroy(EmployeeGenerator.instance);
        EmployeeGenerator.instance = null;
        Destroy(DayTracker.instance);
        DayTracker.instance = null;
        sceneLoader.LoadLevel(SceneLoader.Level.MainMenu);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
