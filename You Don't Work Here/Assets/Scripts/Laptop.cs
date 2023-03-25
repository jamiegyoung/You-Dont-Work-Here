using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour, Interactable
{
    public GameObject laptopUI;

    public GameObject employeeTemplateGameObject;
    public GameObject newEmployeesPanel;
    public GameObject firedEmployeesPanel;
    public GameObject continuingEmployeesPanel;
    public EmployeeGenerator employeeGenerator;

    public void Start()
    {
        laptopUI.SetActive(false);
    }
    public void Interact(GameObject interactor)
    {
        foreach (Employee newEmployee in employeeGenerator.newEmployees)
        {
            GameObject employeeTemplateeGameObjectClone = Instantiate(employeeTemplateGameObject, newEmployeesPanel.transform);
            EmployeeTemplate newTemplate = employeeTemplateeGameObjectClone.GetComponent<EmployeeTemplate>();
            newTemplate.eyes.sprite = newEmployee.eyesSprite;
            newTemplate.mouth.sprite = newEmployee.mouthSprite;
            newTemplate.face.sprite = newEmployee.face.faceSprite;
            newTemplate.face.color = Color.Lerp(
                Color.white,
                new Color32(0x63, 0x4F, 0x3F, 0xFF),
                (float)Random.Range(0, 10) / 10);
            newTemplate.hair.sprite = newEmployee.hairSprite;

            // 1 in 10 chance of being gray
            if (Random.Range(0, 10) == 0)
            {
                newTemplate.hair.color = new Color32(0xCD, 0xCD, 0xCD, 0xFF);
            }
            else
            {
                newTemplate.hair.color = Color.Lerp(
                    new Color32(0xFF, 0xD4, 0x47, 0xFF),
                    new Color32(0x1B, 0x19, 0x17, 0xFF),
                    (float)Random.Range(0, 10) / 10);
            }
            if (newEmployee.wearsGlasses)
            {
                newTemplate.glasses.sprite = newEmployee.face.glassesSprite;
            }
            else
            {
                // Make the glasses transparent
                newTemplate.glasses.color = new Color32(0, 0, 0, 0);
            }

            newTemplate.setFirstName(newEmployee.firstName);
            newTemplate.setLastName(newEmployee.lastName);
        }
        laptopUI.SetActive(true);
    }
}
