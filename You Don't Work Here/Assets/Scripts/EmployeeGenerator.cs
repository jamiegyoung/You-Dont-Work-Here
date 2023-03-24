using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

    public static bool operator ==(SpeechType a, SpeechType b)
    {
        return a.introductionText.SequenceEqual(b.introductionText) &&
               a.takingTimeText.SequenceEqual(b.takingTimeText) &&
               a.acceptionText.SequenceEqual(b.acceptionText) &&
               a.rejectionText.SequenceEqual(b.rejectionText);
    }

    public static bool operator !=(SpeechType a, SpeechType b)
    {
        return !(a == b);
    }

}

[System.Serializable]
public class Employee
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

    public static int Equals(Employee a, Employee b)
    {
        bool tmp = a.speechType == b.speechType;
        int similarities = new[] {
        a.id == b.id,
        a.firstName == b.firstName,
        a.lastName == b.lastName,
        a.speechType == b.speechType,
        a.face.faceSprite == b.face.faceSprite,
        a.hairSprite == b.hairSprite,
        a.eyesSprite == b.eyesSprite,
        a.mouthSprite == b.mouthSprite,
        a.wearsGlasses == b.wearsGlasses
    }.Count(c => c);

        return similarities;
    }

}

public class EmployeeGenerator : MonoBehaviour
{
    private const int SIMILARITY_THRESHOLD = 2;
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
        while (employeesToGenerate > 0)
        {
            // TODO: add similarity check later
            Employee newEmployee = generateRandomEmployee();
            bool remakeFlag = false;
            foreach (Employee e in employees)
            {
                int similarities = Employee.Equals(e, newEmployee);
                Debug.Log("Similarities on generated employee: " + similarities);
                if (similarities > SIMILARITY_THRESHOLD)
                {
                    remakeFlag = true;
                }
            }
            if (!remakeFlag)
            {
                employees.Add(newEmployee);
                employeesToGenerate--;
            }
        }
    }

    private Employee generateRandomEmployee()
    {
        int employeeId = employees.Count;
        Employee employee = new Employee();
        employee.id = employeeId;
        int faceIndex = Random.Range(0, faces.Length);
        employee.face = faces[faceIndex];
        int hairIndex = Random.Range(0, employee.face.hairSprites.Length);
        employee.hairSprite = employee.face.hairSprites[hairIndex];
        int eyesIndex = Random.Range(0, eyeSprites.Length);
        employee.eyesSprite = eyeSprites[eyesIndex];
        int mouthIndex = Random.Range(0, mouthSprites.Length);
        employee.mouthSprite = mouthSprites[mouthIndex];
        employee.wearsGlasses = Random.Range(0, 3) == 0;
        int employeeTypeIndex = Random.Range(0, employeeTypes.Length);
        EmployeeType et = employeeTypes[employeeTypeIndex];
        employee.firstName = et.firstNames[Random.Range(0, et.firstNames.Length)];
        employee.lastName = et.lastNames[Random.Range(0, et.lastNames.Length)];
        employee.speechType = et.speechType;
        return employee;
    }
}
