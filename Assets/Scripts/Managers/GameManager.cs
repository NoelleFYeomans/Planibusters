using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour //High level TODO: Debug Menu, Refactor Code(Urgent)
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

        _SaveManager.loadSave();

        _UIManager.titlescreenUIActive();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _UIManager.optionsActive();
        }
    }
}
