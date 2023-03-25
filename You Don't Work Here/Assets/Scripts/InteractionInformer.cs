using TMPro;
using UnityEngine;

public class InteractionInformer : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject inputPrompt;
    private TextMeshPro inputPromptText;

    void Start()
    {
        gameObject.SetActive(false);
        inputPromptText = inputPrompt.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    public void Show(Vector2 position, string text)
    {

        inputPromptText.text = text;
        transform.position = position;
        gameObject.SetActive(true);
        inputPrompt.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
