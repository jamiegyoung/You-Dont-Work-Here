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
    public List<EmployeeOption> otherOptions;
    public long id;
    public bool locked;

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

    public void SetTicked(bool ticked)
    {
        this.ticked = ticked;
        checkboxImage.sprite = ticked ? checkBoxEnabled : checkBoxDisabled;
    }

    public void OnClick()
    {
        if (locked) return;
        foreach (EmployeeOption option in otherOptions)
        {
            if (option.id != id)
            {
                option.SetTicked(false);
            }
        }
        SetTicked(true);
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
