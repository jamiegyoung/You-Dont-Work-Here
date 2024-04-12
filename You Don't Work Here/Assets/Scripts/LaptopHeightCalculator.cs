using System.Linq;
using UnityEngine;

public class LaptopHeightCalculator : MonoBehaviour
{
    public int padding = 300;
    public RectTransform[] panels;

    void Update()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        float cumulativeY = panels.Sum(p => p.sizeDelta.y);

        Debug.Log(cumulativeY);
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, cumulativeY + padding);
    }
}
