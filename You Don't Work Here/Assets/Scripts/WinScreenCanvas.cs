using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScreenCanvas : MonoBehaviour
{

    public SceneLoader sceneLoader;
    [SerializeField] private TextMeshProUGUI BrotherHappinessText, FatherHappinessText, MotherHappinessText;
    [SerializeField] private ProductsLeft products;
    [SerializeField] private TextMeshProUGUI scoretext;
    private int score = 0;

    void Start()
    {
        if (products.boughtFlowers && products.boughtWine)
        {
            MotherHappinessText.text = "YOUR MOTHER IS VERY PLEASED WITH YOU BECAUSE YOU GOT HER EVERYTHING SHE WANTED,";
            score += 2;
        }
        else if (products.boughtFlowers || products.boughtWine)
        {
            MotherHappinessText.text = "YOUR MOTHER IS ALRIGHT WITH YOUR EXISTENCE BECAUSE YOU GOT HER ONE GIFT,";
            score++;
        }
        else
        {
            MotherHappinessText.text = "YOUR MOTHER STILL HATES YOU BECAUSE YOU GOT HER NO GIFTS,";
        }

        if (products.boughtWatch)
        {
            FatherHappinessText.text = "YOUR FATHER STILL HATES YOU DESPITE GETTING HIM A GIFT,";
            score++;
        }
        else
        {
            FatherHappinessText.text = "YOUR FATHER STILL HATES YOU BECAUSE YOU DID NOT GET HIM A GIFT,";
        }

        if (products.boughtHeadphones)
        {
            BrotherHappinessText.text = "AND YOUR BROTHER IS VERY PLEASED WITH YOU FOR GETTING HIM A GIFT";
            score++;
        }
        else
        {
            BrotherHappinessText.text = "AND YOUR BROTHER IS IMPARTIAL TO YOUR EXISTENCE DESPITE NOT GIVING HIM A GIFT";
        }

        scoretext.text = "YOUR SCORE IS " + score.ToString() + " OUT OF 4";

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
