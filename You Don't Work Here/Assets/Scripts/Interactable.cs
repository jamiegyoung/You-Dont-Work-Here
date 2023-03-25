using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable
{
    bool isInteractable { get; }
    void Interact(GameObject interactor);
}