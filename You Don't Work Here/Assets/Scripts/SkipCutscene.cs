using UnityEngine;

public class SkipCutscene : MonoBehaviour
{
    public SceneLoader sceneLoader;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sceneLoader.LoadLevel(SceneLoader.Levels.House);
        }
    }
}
