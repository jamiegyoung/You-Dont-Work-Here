using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct EmployeeType
{
    public string[] firstNames;
    public string[] lastNames;
    public VoiceType voiceType;
}

[System.Serializable]
public struct FaceType
{
    public Sprite faceSprite;
    public Sprite[] hairSprites;
}

[System.Serializable]
public struct VoiceType
{
    public string[] introductionText;
    public string[] takingTimeText;
    public string[] acceptionText;
    public string[] rejectionText;
}

[System.Serializable]
public struct Employee
{
    public int id;
    public string firstName;
    public string lastName;
    public VoiceType voiceType;
    public FaceType face;
    public Sprite hairSprite;
    public Sprite eyesSprite;
    public Sprite mouthSprite;
}

public class EmployeeGenerator : MonoBehaviour
{
    public FaceType[] faces;
    public Sprite[] eyeSprites;
    public Sprite[] mouthSprites;
    public Sprite[] glassesSprites;
    public EmployeeType[] employeeTypes;
    public List<Employee> employees;
    // Start is called before the first frame update
    public int initialEmployees;
    public int employeeAdditionAmount;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        for (int i = 0; i < initialEmployees - employees.Count; i++)
        {
            int employeeId = employees.Count - 1;
            Employee newEmployee = new Employee();
            newEmployee.id = employeeId;
            int faceIndex = Random.Range(0, faces.Length);
            newEmployee.face = faces[faceIndex];
            int hairIndex = Random.Range(0, newEmployee.face.hairSprites.Length);
            newEmployee.hairSprite = newEmployee.face.hairSprites[hairIndex];
            //newEmployee. = glassesSprites[Random.Range(0, glassesSprites.Length)];
            newEmployee.voiceType = employeeTypes[Random.Range(0, employeeTypes.Length)].voiceType;

            employees.Add(newEmployee);
        }
    }
}
