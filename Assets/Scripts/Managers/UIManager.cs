using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //all the actual canvas objects (may shrink)
    public Canvas titlescreenUI;
    public Canvas gameplayUI;
    public Canvas gameplayTutorialUI;
    public Canvas optionsUI;
    public Canvas winUI;
    public Canvas victoryUI;
    public Canvas loseUI;
    public Canvas creditsUI;
    public Canvas shopUI;

    //Sub-UIs of shop.
    private GameObject singleUI;
    private GameObject rapidUI;
    private GameObject kickUI;

    public Canvas clearSaveUI;
    public GameObject deletionConfirmationUI;

    //enum for all possible UI/Screens/Menus/whatevers
    //public enum UIState
    //{
    //    Titlescreen, //don't forget there needs to be a splash screen before title
    //    Gameplay, //this is the UI that all 3 levels will use
    //    GameplayTutorial, //tutorial UI/text may merge with gameplay?
    //    Options, //for options, access from TitleScreen
    //    Pause, //for pausing midgame, same UI as options mostly, but with different buttons since midgame
    //    Win, //Screen for completing a level
    //    Victory, //UI/Screen for completing game
    //    Lose, //for any level attempt that is unsuccessful
    //    Credits, //accessed from titlescreen
    //    Shop, //shop UI/menu. consider another scene for this entirely?
    //    ClearSave //screen/menu/prompts for clearing save data
    //}

    //SCENES INDEX VALUE
    //Titlescreen = 0
    //ManagerSceneAdditive = 1 //Exists as a place where the Singleton & Managers will originate... maybe
    //ForestLevel = 2
    //MountainLevel = 3
    //FrozenLevel = 4

    // Start is called before the first frame update

    public enum returnUI
    {
        Titlescreen,
        Gameplay
    }

    returnUI returnToUI; //what does this do on load?

    void Start()
    {
        returnToUI = returnUI.Titlescreen; //so this is set on launch

        //this may be changed later
        singleUI = shopUI.transform.GetChild(3).gameObject;
        rapidUI = shopUI.transform.GetChild(4).gameObject;
        kickUI = shopUI.transform.GetChild(5).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //should the UI be managed from the UI Manager's Update? surely?
    }

    public void titlescreenUIActive() //I don't want a bajillion methods that do this, how can I condense?
    {
        disableAllUI();

        titlescreenUI.gameObject.SetActive(true);

        returnToUI = returnUI.Titlescreen;

        Cursor.visible = true; //the cursor wants to be visible since the menu is navigated by mouse/mouse1
    }

    public void gameplayUIActive() //need to check for an existing save file
    {
        disableAllUI();

        gameplayUI.gameObject.SetActive(true);

        returnToUI = returnUI.Gameplay; //this needs to exist for Options to work properly

        Cursor.visible = true; //this needs to be false later!
    }

    public void creditsActive()
    {
        disableAllUI();

        creditsUI.gameObject.SetActive(true);

        Cursor.visible = true;
    }

    public void clearSaveActive()
    {
        disableAllUI();

        clearSaveUI.gameObject.SetActive(true);

        Cursor.visible = true;
    }

    public void optionsActive()
    {
        disableAllUI();

        optionsUI.gameObject.SetActive(true);

        Cursor.visible = true;
    }

    public void shopActive()
    {
        disableAllUI();

        shopUI.gameObject.SetActive(true);
        singleUI.SetActive(true);

        Cursor.visible = true;
    }

    public void confirmDeletion()
    {
        deletionConfirmationUI.SetActive(true);
    }

    public void returnToScene() //used specifically for the pause/options menu
    {
        if (returnToUI == returnUI.Titlescreen) 
        {
            titlescreenUIActive();
        }
        else if (returnToUI == returnUI.Gameplay)
        {
            gameplayUIActive();
        }
    }

    public void disableAllUI() //sets all UIs to inactive
    {
        titlescreenUI.gameObject.SetActive(false);
        gameplayUI.gameObject.SetActive(false);
        gameplayTutorialUI.gameObject.SetActive(false);
        optionsUI.gameObject.SetActive(false);
        //winUI.gameObject.SetActive(false);
        //victoryUI.gameObject.SetActive(false);
        //loseUI.gameObject.SetActive(false);
        creditsUI.gameObject.SetActive(false);
        shopUI.gameObject.SetActive(false);
        clearSaveUI.gameObject.SetActive(false);
        deletionConfirmationUI.SetActive(false);
    }
}
