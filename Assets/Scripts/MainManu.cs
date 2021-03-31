using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManu1: MonoBehaviour
{
    public SceneFader sceneFader;
    public string sceneToLoad;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Bullet"))
        {
            Debug.Log("Hits");
            Application.Quit();
        }
    }
}
