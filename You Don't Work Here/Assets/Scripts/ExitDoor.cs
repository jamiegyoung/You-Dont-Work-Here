using UnityEngine;

public class ExitDoor : MonoBehaviour, Interactable
{

    public SceneLoader sceneLoader;

    public bool IsInteractable => true;

    public void Interact(GameObject interactor)
    {
        sceneLoader.LoadLevel(SceneLoader.Level.Walk);
    }
}
