using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeesPanel : MonoBehaviour
{
    public int elementsPerRow = 4;
    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("child count " + transform.childCount);
        Debug.Log(transform.childCount / elementsPerRow);
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 120 * ((transform.childCount / 4) + 1));
        //Debug.Log(rectTransform.sizeDelta)
        //gridLayout.
    }
}
