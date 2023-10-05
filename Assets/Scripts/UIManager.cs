using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    int currentSceneIndex; //used for storing the index value of the scene

    //enum for all possible UI/Screens/Menus/whatevers
    public enum UIState
    {
        Titlescreen, //don't forget there needs to be a splash screen before title
        Gameplay, //this is the UI that all 3 levels will use
        GameplayTutorial, //tutorial UI/text may merge with gameplay?
        Options, //for options, access from TitleScreen
        Pause, //for pausing midgame, same UI as options mostly, but with different buttons since midgame
        Win, //Screen for completing a level
        Victory, //UI/Screen for completing game
        Lose, //for any level attempt that is unsuccessful
        Credits, //accessed from titlescreen
        Shop, //shop UI/menu. consider another scene for this entirely?
        ClearSave //screen/menu/prompts for clearing save data
    }

    //SCENES INDEX VALUE
    //Titlescreen = 0
    //ManagerSceneAdditive = 1 //Exists as a place where the Singleton & Managers will originate.
    //ForestLevel = 2
    //MountainLevel = 3
    //FrozenLevel = 4

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //should the UI be managed from the UI Manager's Update? surely?
    }

    public void getSceneIndex(int sceneIndex)
    {
        currentSceneIndex = sceneIndex; //I now have the scene index and can use this value to load the UI of the relevent scene?
    }

    //do I make actual UI objects in Unity, or code UI? Decide soonish~
}
