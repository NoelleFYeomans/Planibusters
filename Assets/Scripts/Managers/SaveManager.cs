using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SaveManager : MonoBehaviour //pontially remove from unity and instantiate this code INTO the GameManager
{
    public static SaveManager Instance; //Really, this should be called DataManager, but alas

    public float experience;
    public int level;
    public int attemptCount;
    public bool isTutorialComplete;

    public int singlePower = 1, singleAccuracy = 1, singleBalance = 1, singleUnique = 1; //implemented
    public int rapidPower = 1, rapidAccuracy = 1, rapidBalance = 1, rapidUnique = 1; //might be removed
    public int kickPower = 1, kickAccuracy = 1, kickBalance = 1, kickUnique = 1;

    //there should be a list/array of values that keep track of current upgrades?

    // Start is called before the first frame update
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
    }

    public void incrementAttempt()
    {
        attemptCount++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save() //SaveData method
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat"); //creates a save
        PlayerData data = new PlayerData(); //creates a PlayerData object to populate with data

        //apply current info to save data below. IE: data.health = health
        data.experience = experience;
        data.level = level;
        data.attemptCount = attemptCount;
        data.isTutorialComplete = isTutorialComplete;

        //single stats
        data.singlePower = singlePower;
        data.singleAccuracy = singleAccuracy;
        data.singleBalance = singleBalance;
        data.singleCritical = singleUnique;

        //finishes the writing and closes the file
        bf.Serialize(file, data);
        file.Close();

    }

    public void loadSave() //loadSaveData method
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) //looks for player save
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open); //opens player save
            PlayerData data = (PlayerData)bf.Deserialize(file); //brings data into game
            file.Close(); //closes the file

            //apply saved data info below. IE: health = data.health
            experience = data.experience;
            level = data.level;
            attemptCount = data.attemptCount;
            isTutorialComplete = data.isTutorialComplete;

            //single stats
            singlePower = data.singlePower;
            singleAccuracy = data.singleAccuracy;
            singleBalance = data.singleBalance;
            singleUnique = data.singleCritical;
        }
    }

    public void clearSave() //calling this method will delete all save data
    {
        Debug.Log("clear accessed");
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            File.Delete(Application.persistentDataPath + "/playerInfo.dat"); //this deletes the save file
            Debug.Log("clear performed");
        }
    }
}

//class exists to be a place where I can serialize the data pertinent to the player's progression;
[Serializable] //<<< poggers????
class PlayerData
{
    //generic variables
    public float experience;
    public int level;
    public int attemptCount;
    public bool isTutorialComplete;

    //single style variables
    public int singlePower;
    public int singleAccuracy;
    public int singleBalance;
    public int singleCritical;

    //rapid style variables

    //kick style variables


}
