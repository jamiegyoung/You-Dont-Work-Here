using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionInteractableLoader : MonoBehaviour, Interactable
{
    public SceneLoader sceneLoader;

    public bool IsInteractable => true;

    public void Interact(GameObject interactor)
    {
        sceneLoader.LoadLevel(SceneLoader.Levels.Reception);
    }

}
