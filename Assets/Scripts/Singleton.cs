using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    // Singleton Pattern exists so that only 1 GameManager(&children) ever exist

    static Singleton Instance;

    void Start()
    {
        if (Instance != null)
        {
            GameObject.Destroy(gameObject); //destroys the GameManager if it already exists on start
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject); //otherwise makes a GameManager that doesn't destroy between scenes
            Instance = this;
        }
    }
}
