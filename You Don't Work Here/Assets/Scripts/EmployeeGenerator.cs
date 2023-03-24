using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct EmployeeType
{
    public string[] firstNames;
    public string[] lastNames;
    public SpeechType speechType;
}

[System.Serializable]
public struct FaceType
{
    public Sprite faceSprite;
    public Sprite glassesSprite;
    public Sprite[] hairSprites;
}

[System.Serializable]
public struct SpeechType
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
    public SpeechType speechType;
    public FaceType face;
    public Sprite hairSprite;
    public Sprite eyesSprite;
    public Sprite mouthSprite;
    public bool wearsGlasses;
}

public class EmployeeGenerator : MonoBehaviour
{
    public FaceType[] faces;
    public Sprite[] eyeSprites;
    public Sprite[] mouthSprites;
    public EmployeeType[] employeeTypes;
    public List<Employee> employees;
    public int initialEmployees;
    public int employeeAdditionAmount;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        int employeesToGenerate = initialEmployees - employees.Count;
        for (int i = 0; i < employeesToGenerate; i++)
        {
            // TODO: add similarity check later
            employees.Add(generateRandomEmployee());
        }
    }

    private Employee generateRandomEmployee()
    {
        int employeeId = employees.Count;
        Employee newEmployee = new Employee();
        newEmployee.id = employeeId;
        int faceIndex = Random.Range(0, faces.Length);
        newEmployee.face = faces[faceIndex];
        int hairIndex = Random.Range(0, newEmployee.face.hairSprites.Length);
        newEmployee.hairSprite = newEmployee.face.hairSprites[hairIndex];
        int eyesIndex = Random.Range(0, eyeSprites.Length);
        newEmployee.eyesSprite = eyeSprites[eyesIndex];
        int mouthIndex = Random.Range(0, mouthSprites.Length);
        newEmployee.mouthSprite = mouthSprites[mouthIndex];
        newEmployee.wearsGlasses = Random.Range(0, 3) == 0;
        int employeeTypeIndex = Random.Range(0, employeeTypes.Length);
        EmployeeType et = employeeTypes[employeeTypeIndex];
        newEmployee.firstName = et.firstNames[Random.Range(0, et.firstNames.Length)];
        newEmployee.lastName = et.lastNames[Random.Range(0, et.lastNames.Length)];
        newEmployee.speechType = et.speechType;
        return newEmployee;
    }
}
