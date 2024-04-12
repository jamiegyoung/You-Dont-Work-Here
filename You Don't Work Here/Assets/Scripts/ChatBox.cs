using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class ChatBox : MonoBehaviour
{

    [SerializeField] private TMP_Text textMeshPro;
    public static bool isLoaded;

    public void PrintText(string text)
    {
        PrintText(text, Color.black);
    }

    public void PrintText(string text, Color color)
    {
        
        StartCoroutine(PrintMessage(text, color));
    }

    private IEnumerator PrintMessage(string text, Color32 color)
    {
        
        ClearChatBox();
        textMeshPro.color = color;
        textMeshPro.text += '"';
        foreach (char c in text)
        {
            textMeshPro.text += c;
            yield return new WaitForSeconds(0.02f);
        }
        textMeshPro.text += '"';
        isLoaded = true;

    }

    public void ClearChatBox()
    {
        textMeshPro.text = "";
        textMeshPro.color = Color.black;
        isLoaded = false;
    }
}
