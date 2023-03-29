using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class ChatBox : MonoBehaviour
{

    [SerializeField] private GameObject textBox;
  

    public void PrintText(string text)
    {
        PrintText(text, Color.black);
    }

    public void PrintText(string text, Color color)
    {
        StartCoroutine(PrintMessage(text, color));
    }

    private IEnumerator PrintMessage(string text, Color color)
    {
        ClearChatBox();
        textBox.GetComponent<TextMeshProUGUI>().faceColor = color;
        textBox.GetComponent<TextMeshProUGUI>().text += '"';
        foreach (char c in text)
        {
            textBox.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(0.05f);
        }
        textBox.GetComponent<TextMeshProUGUI>().text += '"';


    }

    public void ClearChatBox()
    {
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        textBox.GetComponent<TextMeshProUGUI>().faceColor = Color.black;
    }
}
