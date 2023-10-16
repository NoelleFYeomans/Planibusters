using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

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

    public Canvas resultsUI;

    //Sub-UIs of shop.
    private GameObject singleUI;
    private GameObject rapidUI;
    private GameObject kickUI;

    public Canvas clearSaveUI;
    public GameObject deletionConfirmationUI;

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
        Gameplay,
        Shop
    }

    returnUI returnToUI; //what does this do on load?

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // Handle duplicate instances, or take appropriate action.
            Destroy(this.gameObject);
        }

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

    public void resultsUIActive()
    {
        resultsUI.gameObject.SetActive(true);

        Cursor.visible = true;
    }

    public void creditsActive()
    {
        creditsUI.gameObject.SetActive(true);

        Cursor.visible = true;
    }

    public void clearSaveActive()
    {
        clearSaveUI.gameObject.SetActive(true);

        Cursor.visible = true;
    }

    public void optionsActive()
    {
        //disableAllUI();

        optionsUI.gameObject.SetActive(true);

        Cursor.visible = true;
    }

    public void shopActive()
    {
        disableAllUI();

        shopUI.gameObject.SetActive(true);

        returnToUI = returnUI.Shop;

        singleUI.SetActive(true); //this should set the current style active

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
        else if (returnToUI == returnUI.Shop)
        {
            shopActive();
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
        resultsUI.gameObject.SetActive(false);

    }
}
