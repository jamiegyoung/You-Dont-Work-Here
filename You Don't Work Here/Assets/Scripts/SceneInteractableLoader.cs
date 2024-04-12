using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInteractableLoader : MonoBehaviour, Interactable
{
    public SceneLoader sceneLoader;
    public SceneLoader.Level level;
    public bool IsInteractable => true;
    private AudioSource sfx;

    public void Interact(GameObject interactor)
    {
        if (level.ToString()== "Walk"){
            sfx = GetComponent<AudioSource>();
            sfx.Play(0);
        }
        if (level.ToString()== "Reception"){
            sfx = GetComponent<AudioSource>();
            sfx.Play(0);
        }
        sceneLoader.LoadLevel(level);
    }

}
