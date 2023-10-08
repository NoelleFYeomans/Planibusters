using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour //consider a debug menu
{
    //where unity references to other managers are passed in
    public GameObject LevelManager;
    public GameObject UIManager;
    public GameObject ShopManager;

    //the empty objects where the referenced managers will be stored
    private LevelManager _levelManager;
    private UIManager _UIManager;
    private ShopManager _ShopManager;
    private SaveManager _SaveManager;

    //enums for what state the game is in
    public enum GameState //what do I *need* this for?
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

        _UIManager.getSceneIndex(_levelManager.returnSceneIndex()); //this feeds the index of the current scene to _UIManager without having to add SceneManager library to UIManager script
    }

    // Update is called once per frame
    void Update()
    {
        //I have 6 buttons + mouse 1. Should I put this in an inputManager? (I don't think I will)
        switch (_gameState)
        {
            case GameState.Titlescreen:
                //run any settings/code relevent to the titlescreen
                break;
            case GameState.Gameplay: 
                //this is where inputs should be accepted //NOTE: do something about unity input manager
                //how am I going to handle the multiple input styles?
                break;
            case GameState.Paused:
                //this is for pause & potentially upgrade UIs?
                break; 
            case GameState.Other:
                //no use yet, may be changed/removed
                break;

        }

    }
}
