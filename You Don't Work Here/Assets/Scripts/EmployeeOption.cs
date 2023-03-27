using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeOption : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public bool ticked;
    public Image checkboxImage;
    public Sprite checkBoxEnabled;
    public Sprite checkBoxDisabled;
    public RectTransform scrollRectContent;
    public long id;

    public void Start()
    {
        ScrollRect scrollRect = GetComponent<ScrollRect>();
        scrollRect.content = scrollRectContent;
        ticked = false;
        checkboxImage.sprite = checkBoxDisabled;
    }

    public void OnClick()
    {
        ticked = !ticked;
        checkboxImage.sprite = ticked ? checkBoxEnabled : checkBoxDisabled;
        Debug.Log(ticked);
    }

    public void OnMouseEnter()
    {
        checkboxImage.sprite = checkBoxEnabled;
    }

    public void OnMouseExit()
    {
        if (!ticked)
        {
            checkboxImage.sprite = checkBoxDisabled;
        }
    }
}
