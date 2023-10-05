using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //SCENES INDEX VALUE
    //Titlescreen = 0
    //ManagerSceneAdditive = 1 //Exists as a place where the Singleton & Managers will originate.
    //ForestLevel = 2
    //MountainLevel = 3
    //FrozenLevel = 4

    public int returnSceneIndex() //gives the scene index value of the currently loaded scene
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void loadTitlescreen() //Called to load into titlescreen
    {
        SceneManager.LoadScene(0); //scene 0 IS the titlescreen
    }

    public void loadManagerScene() //this method will load the scene containing all Managers... but where and how do I call this? perhaps I simply attach singleton to mainmenu and let it be
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void loadScene(int sceneIndexValue) //perhaps feed in an int, use scene index to load?
    {
        if (sceneIndexValue == 1) return; //I do not want the game to EVER load into scene 1(the managerScene)
        SceneManager.LoadScene(sceneIndexValue); //this will load in whatever scene the passed in Int is
    }

    public void quitGame() //exits game
    {
        Application.Quit();
    }
}
