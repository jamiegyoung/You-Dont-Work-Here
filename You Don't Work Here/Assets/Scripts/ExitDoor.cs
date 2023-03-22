using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour, Interactable
{

    public SceneLoader sceneLoader;

    public void Interact(GameObject interactor)
    {
        sceneLoader.LoadLevel(SceneLoader.Levels.Walk);
    }
}
