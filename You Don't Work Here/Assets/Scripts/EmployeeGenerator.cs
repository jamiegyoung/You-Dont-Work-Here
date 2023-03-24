using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

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
        AddEmployees(employeesToGenerate);
    }

    /// <summary>
    /// Adds new employees to the current employees
    /// </summary>
    /// <param name="employeesToGenerate">The number of employees to generate</param>
    /// <returns>A list of the added employees</returns>
    public List<Employee> AddEmployees(int employeesToGenerate)
    {
        List<Employee> newEmployees = new();
        while (employeesToGenerate > 0)
        {
            // TODO: add similarity check later
            Employee newEmployee = GenerateRandomEmployee();
            bool remakeFlag = false;
            foreach (Employee e in employees)
            {
                int similarities = e.Equals(newEmployee);
                Debug.Log("Similarities on generated employee: " + similarities);
                if (similarities > SIMILARITY_THRESHOLD)
                {
                    remakeFlag = true;
                }
            }
            if (!remakeFlag)
            {
                employees.Add(newEmployee);
                newEmployees.Add(newEmployee);
                employeesToGenerate--;
            }
        }
        return newEmployees;
    }

    /// <summary>
    /// Generates a random employee
    /// </summary>
    /// <returns>The randomly generated employee</returns>
    private Employee GenerateRandomEmployee()
    {
        int employeeId = employees.Count;
        int faceIndex = Random.Range(0, faces.Length);
        int hairIndex = Random.Range(0, faces[faceIndex].hairSprites.Length);
        int eyesIndex = Random.Range(0, eyeSprites.Length);
        int mouthIndex = Random.Range(0, mouthSprites.Length);
        int employeeTypeIndex = Random.Range(0, employeeTypes.Length);
        EmployeeType et = employeeTypes[employeeTypeIndex];

        Employee employee = new()
        {
            id = employeeId,
            face = faces[faceIndex],
            hairSprite = faces[faceIndex].hairSprites[hairIndex],
            eyesSprite = eyeSprites[eyesIndex],
            mouthSprite = mouthSprites[mouthIndex],
            wearsGlasses = Random.Range(0, 3) == 0,
            firstName = et.firstNames[Random.Range(0, et.firstNames.Length)],
            lastName = et.lastNames[Random.Range(0, et.lastNames.Length)],
            speechType = et.speechType
        };
        return employee;
    }
}
