using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EmployeeHandler : MonoBehaviour
{
    public GameObject employee;

    // Start is called before the first frame update
    void Start()
    {
        Employee tmp = EmployeeGenerator.employeeGeneratorInstance.employees[0];
        PlayableDirector a = employee.GetComponent<PlayableDirector>();
        a.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
