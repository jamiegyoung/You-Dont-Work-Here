using UnityEngine;

public interface Interactable
{
    bool IsInteractable { get; }
    void Interact(GameObject interactor);
}