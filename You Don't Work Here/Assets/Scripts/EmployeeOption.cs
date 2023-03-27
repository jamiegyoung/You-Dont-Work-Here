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
    private bool locked;

    public void Start()
    {
        ScrollRect scrollRect = GetComponent<ScrollRect>();
        scrollRect.content = scrollRectContent;
        ticked = false;
        checkboxImage.sprite = checkBoxDisabled;
    }

    public void OnAccept()
    {
        if (ticked)
        {
            locked = true;
        }
    }

    public void OnClick()
    {
        if (locked) return;
        ticked = !ticked;
        checkboxImage.sprite = ticked ? checkBoxEnabled : checkBoxDisabled;
        Debug.Log(ticked);
    }

    public void OnMouseEnter()
    {
        if (locked) return;
        checkboxImage.sprite = checkBoxEnabled;
    }

    public void OnMouseExit()
    {
        if (locked) return;
        if (!ticked)
        {
            checkboxImage.sprite = checkBoxDisabled;
        }
    }
}
