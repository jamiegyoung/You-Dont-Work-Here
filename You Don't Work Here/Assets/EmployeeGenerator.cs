using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct EmployeeType
{
    public string[] FirstNames;
    public string[] LastNames;
    public VoiceType voiceType;
}

[System.Serializable]
public struct VoiceType
{
    public string[] IntroductionText;
    public string[] TakingTimeText;
    public string[] AcceptionText;
    public string[] RejectionText;
}

[System.Serializable]
public struct Employee
{
    public int Id;
    public string FirstName;
    public string LastName;
    public VoiceType VoiceType;
    public Sprite face;
    public Sprite hair;
    public Sprite beard;
    public Sprite glasses;
}

public class EmployeeGenerator : MonoBehaviour
{
    public Sprite[] faceSprites;
    public Sprite[] hairSprites;
    public Sprite[] beardSprites;
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
            newEmployee.Id = employeeId;
            newEmployee.face = faceSprites[Random.Range(0, faceSprites.Length)];
            newEmployee.hair = hairSprites[Random.Range(0, hairSprites.Length)];
            newEmployee.beard = beardSprites[Random.Range(0, beardSprites.Length)];
            newEmployee.glasses = glassesSprites[Random.Range(0, glassesSprites.Length)];
            newEmployee.VoiceType = employeeTypes[Random.Range(0, employeeTypes.Length)].voiceType;

            employees.Add(newEmployee);
        }
    }
}
