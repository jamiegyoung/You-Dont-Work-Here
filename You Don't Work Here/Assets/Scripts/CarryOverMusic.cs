using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryOverMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("IntroMusic");
        if(music.Length > 1){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
