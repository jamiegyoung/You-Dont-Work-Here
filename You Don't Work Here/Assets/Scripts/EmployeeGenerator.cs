using JetBrains.Annotations;
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
    public int initialEmployees = 4;
    public int employeeAdditionAmount = 1;
    public List<Employee> newEmployees;
    public List<Employee> firedEmployees;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        int employeesToGenerate = initialEmployees - employees.Count;
        AddEmployees(employeesToGenerate);
        AddEmployees(employeesToGenerate);
        FireEmployees(2);
    }

    /// <summary>
    /// Adds new employees to the current employees
    /// </summary>
    /// <param name="employeesToGenerate">The number of employees to generate</param>
    /// <returns>A list of the added employees</returns>
    public List<Employee> AddEmployees(int employeesToGenerate)
    {
        this.newEmployees = new List<Employee>();
        List<Employee> newEmployees = new();
        while (employeesToGenerate > 0)
        {
            // TODO: add similarity check later
            Employee newEmployee = GenerateRandomEmployee();
            bool remakeFlag = false;
            foreach (Employee e in employees)
            {
                int similarities = e.Equals(newEmployee);
                //Debug.Log("Similarities on generated employee: " + similarities);
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
        this.newEmployees = newEmployees;
        return newEmployees;
    }

    /// <summary>
    /// Fires a given amount of employees
    /// </summary>
    /// <param name="employeesToFire">The number of employees to fire</param>
    /// <returns>A list of fired employees</returns>
    public List<Employee> FireEmployees(int employeesToFire)
    {
        firedEmployees = new List<Employee>();

        for (int i = 0; i < employeesToFire; i++)
        {
            if (employees.Count > 0)
            {
                int randomIndex = Random.Range(0, employees.Count);
                firedEmployees.Add(employees[randomIndex]);
                // Just in-case they were hired and fired very quickly
                newEmployees.Remove(employees[randomIndex]);
                employees.RemoveAt(randomIndex);
            }
        }
        return firedEmployees;
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
            faceColor = Color.Lerp(
                Color.white,
                new Color32(0x63, 0x4F, 0x3F, 0xFF),
                (float)Random.Range(0, 10) / 10),
            hairSprite = faces[faceIndex].hairSprites[hairIndex],
            hairColor = GenerateHairColor(),
            eyesSprite = eyeSprites[eyesIndex],
            mouthSprite = mouthSprites[mouthIndex],
            wearsGlasses = Random.Range(0, 3) == 0,
            firstName = et.firstNames[Random.Range(0, et.firstNames.Length)],
            lastName = et.lastNames[Random.Range(0, et.lastNames.Length)],
            speechType = et.speechType
        };
        return employee;
    }

    private static Color GenerateHairColor()
    {
        if (Random.Range(0, 10) == 0)
        {
            return new Color32(0xCD, 0xCD, 0xCD, 0xFF);
        }
        return Color.Lerp(
            new Color32(0xFF, 0xD4, 0x47, 0xFF),
            new Color32(0x1B, 0x19, 0x17, 0xFF),
            (float)Random.Range(0, 10) / 10);
    }
}
