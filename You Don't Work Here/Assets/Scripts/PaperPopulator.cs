using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPopulator : MonoBehaviour
{
    public GameObject employeeOptionTemplate;
    public RectTransform paperContainerRectTransform;
    public RectTransform paperPanelRectTransform;
    public Transform paperPanelTransform;
    private EmployeeGenerator eg;
    void Start()
    {
        eg = EmployeeGenerator.instance;
        paperContainerRectTransform.sizeDelta = new Vector2(paperContainerRectTransform.sizeDelta.x, 28 * eg.employees.Count + 100);
        paperPanelRectTransform.sizeDelta = new Vector2(paperPanelRectTransform.sizeDelta.x, 28 * eg.employees.Count + 25);
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
