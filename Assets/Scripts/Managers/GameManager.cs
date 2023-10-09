using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour //MAKE A DEBUG MENU!!!!!!!!
{
    //where unity references to other managers are passed in
    public GameObject LevelManager;
    public GameObject UIManager;
    public GameObject ShopManager;
    public GameObject AudioManager;

    //the empty objects where the referenced managers will be stored
    private LevelManager _levelManager;
    private UIManager _UIManager;
    private ShopManager _ShopManager;
    private SaveManager _SaveManager;
    private AudioManager _AudioManager;

    //enums for what state the game is in
    public enum GameState //What am i actually using these for tbh?
    {
        Titlescreen, //the game is on the titlescreen
        Gameplay, //the game is in the middle of gameplay
        Paused, //the game is paused or otherwise in some type of non-gameplay/title UI/scene
        Other //use TBD
    }

    private GameState _gameState;

    // Start is called before the first frame update
    void Start()
    {
        //sets the private objects with a reference to said objects, finding their scripts
        _levelManager = LevelManager.GetComponent<LevelManager>();
        _UIManager = UIManager.GetComponent<UIManager>();
        _ShopManager = ShopManager.GetComponent<ShopManager>();
        _SaveManager = GetComponent<SaveManager>(); //this gets the SaveManager script off of GameManager object
        _AudioManager = AudioManager.GetComponent<AudioManager>();

        _UIManager.titlescreenUIActive();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _UIManager.optionsActive(); //this just works lmfaooooo
        }

        //I have 6 buttons + mouse 1. Should I put this in an inputManager? (I don't think I will)
        //switch (_gameState)
        //{
        //    case GameState.Titlescreen:
        //        //run any settings/code relevent to the titlescreen
        //        break;
        //    case GameState.Gameplay: 
        //        if (Input.GetKeyDown(KeyCode.Escape))
        //        {
        //            _UIManager.optionsActive(); //this probably doesn't work fully yet
        //        }
        //        break;
        //    case GameState.Paused:
        //        //this is for pause & potentially upgrade UIs?
        //        break; 
        //    case GameState.Other:
        //        //no use yet, may be changed/removed
        //        break;

        //}

    }
}
