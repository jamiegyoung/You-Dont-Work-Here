using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Money Objects/Products")]
public class ProductsLeft : ScriptableObject
{
    public int flowersCount = 20;
    public int wineCount = 15;
    public int headphonesCount = 10;
    public int watchCount = 5;

    public bool boughtFlowers = false;
    public bool boughtHeadphones = false;
    public bool boughtWatch = false;
    public bool boughtWine = false;

    public enum Products
    {
        Flowers,
        Wine,
        Headphones,
        Watch
    }
    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

    public void decrementSupply()
    {
        if (DayTracker.instance.currentDay >1)
        {
            flowersCount -= 4;
            wineCount -= 3;
            headphonesCount -= 2;
            watchCount--;
            if (DayTracker.instance.currentDay % 2 == 0)
            {
                watchCount--;
                flowersCount--;
            }
        }
    }

    public bool buyProduct(Products product)
    {
        if (product == Products.Flowers)
        {
            if (flowersCount > 0)
            {
                boughtFlowers = true;
                flowersCount--;
                return true;
            }
        }
        else if (product == Products.Wine)
        {
            if (wineCount > 0)
            {
                boughtWine = true;
                wineCount--;
                return true;
            }
        }
        else if (product == Products.Headphones)
        {
            if (headphonesCount > 0)
            {
                boughtHeadphones = true;
                headphonesCount--;
                return true;
            }
        }
        else if (product == Products.Watch)
        {
            if (watchCount > 0)
            {
                boughtWatch = true;
                watchCount--;
                return true;
            }
        }
        return false;
    }

    public int GetCount(Products product)
    {
        if (product == Products.Flowers)
        {
            return flowersCount;
        }
        else if (product == Products.Wine)
        {
            return wineCount;
        }
        else if (product == Products.Headphones)
        {
            return headphonesCount;
        }
        else
        {
            return watchCount;
        }
    }

    public bool CheckBought(Products product)
    {
        if (product == Products.Flowers)
        {
            return boughtFlowers;
        }
        else if (product == Products.Wine)
        {
            return boughtWine;
        }
        else if (product == Products.Headphones)
        {
            return boughtHeadphones;
        }
        else
        {
            return boughtWatch;
        }
    }

    public void ResetValues()
    {
        flowersCount = 20;
        wineCount = 15;
        headphonesCount = 10;
        watchCount = 5;
        boughtFlowers = false;
        boughtWine = false;
        boughtHeadphones = false;
        boughtWatch = false;
    }

    
}
