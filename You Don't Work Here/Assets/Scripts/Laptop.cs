using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Laptop : MonoBehaviour, Interactable
{
    public GameObject laptopUI;

    public GameObject employeeTemplateGameObject;
    public GameObject newEmployeesPanel;
    public GameObject newEmployeesText;
    public GameObject firedEmployeesPanel;
    public GameObject firedEmployeesText;
    public GameObject continuingEmployeesPanel;
    public GameObject continuingEmployeesText;
    public EmployeeGenerator employeeGenerator;
    public PlayerInput playerInput;
    private InputHandler inputHandler;

    //public bool isInteractable => !laptopUI.activeInHierarchy;
    public bool IsInteractable => true;

    public void Start()
    {
        inputHandler = new InputHandler(playerInput);
        laptopUI.SetActive(false);
    }

    public void Update()
    {
        if (inputHandler.WasPressedThisFrame(InputHandlerActions.Pause))
        {
            Close();
        }
    }

    private void GeneratePhotos(List<Employee> employees, GameObject employeesPanel)
    {
        foreach (Transform child in employeesPanel.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Employee employee in employees)
        {
            GameObject employeeTemplateGameObjectClone = Instantiate(employeeTemplateGameObject, employeesPanel.transform);
            EmployeeTemplate template = employeeTemplateGameObjectClone.GetComponent<EmployeeTemplate>();
            template.eyes.sprite = employee.eyesSprite;
            template.mouth.sprite = employee.mouthSprite;
            template.face.sprite = employee.face.faceSprite;
            template.face.color = employee.faceColor;

            // 1 in 10 chance of being gray
            template.hair.sprite = employee.hairSprite;
            template.hair.color = employee.hairColor;
            if (employee.wearsGlasses)
            {
                template.glasses.sprite = employee.face.glassesSprite;
            }
            else
            {
                // Make the glasses transparent
                template.glasses.color = new Color32(0, 0, 0, 0);
            }

            template.SetFirstName(employee.firstName);
            template.SetLastName(employee.lastName);
        }
    }

    public void Close()
    {
        laptopUI.SetActive(false);
    }

    public void Interact(GameObject interactor)
    {
        ToggleEmployeesGrid(employeeGenerator.newEmployees, newEmployeesPanel, newEmployeesText);
        GeneratePhotos(employeeGenerator.newEmployees, newEmployeesPanel);

        ToggleEmployeesGrid(employeeGenerator.firedEmployees, firedEmployeesPanel, firedEmployeesText);
        GeneratePhotos(employeeGenerator.firedEmployees, firedEmployeesPanel);

        List<Employee> remainingEmployees = employeeGenerator.employees.Except(employeeGenerator.newEmployees).ToList();

        ToggleEmployeesGrid(remainingEmployees, continuingEmployeesPanel, continuingEmployeesText);
        GeneratePhotos(remainingEmployees, continuingEmployeesPanel);
        laptopUI.SetActive(true);
    }

    private void ToggleEmployeesGrid(List<Employee> employees, GameObject panel, GameObject text)
    {
        if (employees.Count == 0)
        {
            panel.SetActive(false);
            text.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
            text.SetActive(true);
        }
    }
}
