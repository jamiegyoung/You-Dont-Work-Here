using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPopulator : MonoBehaviour
{
    public GameObject employeeOptionTemplate;
    public RectTransform paperContainerRectTransform;
    public Transform paperPanelTransform;
    private EmployeeGenerator eg;
    void Start()
    {
        eg = EmployeeGenerator.instance;
        List<Employee> employeesToProcess = new(eg.employees);
        while (employeesToProcess.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, employeesToProcess.Count);
            Employee employee = employeesToProcess[randomIndex];
            GameObject newEmployeeOption = Instantiate(employeeOptionTemplate, paperPanelTransform);
            EmployeeOption employeeOption = newEmployeeOption.GetComponent<EmployeeOption>();
            employeeOption.tmp.text = employee.firstName + " " + employee.lastName;
            employeeOption.id = employee.id;
            employeesToProcess.RemoveAt(randomIndex);
            employeeOption.scrollRectContent = paperContainerRectTransform;
        }
    }
}
