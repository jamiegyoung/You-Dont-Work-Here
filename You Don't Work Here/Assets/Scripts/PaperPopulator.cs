using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPopulator : MonoBehaviour
{
    public GameObject employeeOptionTemplate;
    public RectTransform paperContainerRectTransform;
    public EmployeeHandler eh;
    public RectTransform paperPanelRectTransform;
    public Transform paperPanelTransform;
    private EmployeeGenerator eg;
    private List<EmployeeOption> options;
    void Start()
    {
        options = new List<EmployeeOption>();
        eg = EmployeeGenerator.instance;
        paperContainerRectTransform.sizeDelta = new Vector2(paperContainerRectTransform.sizeDelta.x, 25 * eg.employees.Count + 100);
        paperPanelRectTransform.sizeDelta = new Vector2(paperPanelRectTransform.sizeDelta.x, 25 * eg.employees.Count + 25);
        List<Employee> employeesToProcess = new(eg.employees);
        while (employeesToProcess.Count > 0)
        {
            int randomIndex = Random.Range(0, employeesToProcess.Count);
            Employee employee = employeesToProcess[randomIndex];
            GameObject newEmployeeOption = Instantiate(employeeOptionTemplate, paperPanelTransform);
            EmployeeOption employeeOption = newEmployeeOption.GetComponent<EmployeeOption>();
            employeeOption.tmp.text = employee.firstName + " " + employee.lastName;
            employeeOption.id = employee.id;
            employeesToProcess.RemoveAt(randomIndex);
            employeeOption.scrollRectContent = paperContainerRectTransform;
            options.Add(employeeOption);
            employeeOption.otherOptions = options;
        }
    }

    public void OnAccept()
    {
        EmployeeOption validOption = CheckAcceptValidity();
        Debug.Log(validOption.id);
        if (validOption == null) return;
        eh.SetAccepted(validOption);
        validOption.SetTicked(true); // just incase
        validOption.locked = true;
    }

    public void OnReject()
    {
        foreach (EmployeeOption option in options)
        {
            option.SetTicked(false);
        }
        eh.SetRejected();
    }

    private EmployeeOption CheckAcceptValidity()
    {
        bool valid = false;
        EmployeeOption selectedOption = null;
        foreach (EmployeeOption option in options)
        {
            if (option.ticked == true && option.locked == false)
            {
                // if a non locked option is picked and another hasn't been picked before it's valid
                if (valid == false)
                {
                    selectedOption = option;
                }
                else
                {
                    selectedOption = null;
                }
            }
        }
        return selectedOption;
    }
}

