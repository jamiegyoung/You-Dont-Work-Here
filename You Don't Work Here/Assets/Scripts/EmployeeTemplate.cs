using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeTemplate : MonoBehaviour
{
    public Image face;
    public Image mouth;
    public Image eyes;
    public Image hair;
    public Image glasses;
    public TextMeshProUGUI text;

    public string _firstName;
    public string _lastName;

    public void SetFirstName(string firstName)
    {
        _firstName = firstName;
        text.text = _firstName + " " + _lastName;
    }

    public void SetLastName(string lastName)
    {
        _lastName = lastName;
        text.text = _firstName + " " + _lastName;
    }
}
