using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    int currentSceneIndex; //used for storing the index value of the scene

    //all the actual canvas objects (may shrink)
    public Canvas titlescreenUI;
    public Canvas gameplayUI;
    public Canvas gameplayTutorialUI;
    public Canvas optionsUI;
    public Canvas pauseUI;
    public Canvas winUI;
    public Canvas victoryUI;
    public Canvas loseUI;
    public Canvas creditsUI;
    public Canvas shopUI;
    public Canvas clearSaveUI;

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
    //ManagerSceneAdditive = 1 //Exists as a place where the Singleton & Managers will originate... maybe
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

    public void titlescreenUIActive() //I don't want a bajillion methods that do this, how can I condense?
    {
        disableAllUI();

        titlescreenUI.gameObject.SetActive(true);

        Cursor.visible = true; //the cursor wants to be visible since the menu is navigated by mouse/mouse1
    }

    public void gameplayUIActive() //need to check for an existing save file
    {
        disableAllUI();

        gameplayUI.gameObject.SetActive(true);

        Cursor.visible = false;
    }

    public void creditsActive()
    {
        disableAllUI();

        creditsUI.gameObject.SetActive(true);

        Cursor.visible = true;
    }

    public void disableAllUI() //sets all UIs to inactive
    {
        titlescreenUI.gameObject.SetActive(false);
        gameplayUI.gameObject.SetActive(false);
        //gameplayTutorialUI.gameObject.SetActive(false);
        //optionsUI.gameObject.SetActive(false);
        //pauseUI.gameObject.SetActive(false);
        //winUI.gameObject.SetActive(false);
        //victoryUI.gameObject.SetActive(false);
        //loseUI.gameObject.SetActive(false);
        creditsUI.gameObject.SetActive(false);
        shopUI.gameObject.SetActive(false);
        //clearSaveUI.gameObject.SetActive(false);
    }
}
