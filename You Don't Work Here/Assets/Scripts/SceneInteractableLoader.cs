using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInteractableLoader : MonoBehaviour, Interactable
{
    public SceneLoader sceneLoader;
    public SceneLoader.Level level;
    public bool IsInteractable => true;

    public void Interact(GameObject interactor)
    {
        sceneLoader.LoadLevel(level);
    }

}
