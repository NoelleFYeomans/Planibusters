using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance; //Really, this should be called DataManager, but alas

    public float experience;
    public int level;
    public int attemptCount;
    public bool isTutorialComplete;
    //there should be a list/array of values that keep track of current upgrades?

    // Start is called before the first frame update
    void Start()
    {
        //inits values for gameplay, may need to be changed if start is *ever* called again (IE: loading a new scene calls this for some reason)
        experience = 0;
        level = 1;
        attemptCount = 0;
        isTutorialComplete = false;
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
        }
    }

    public void clearSave() //calling this method will delete all save data
    {
        
    }
}

//class exists to be a place where I can serialize the data pertinent to the player's progression;
[Serializable]
class PlayerData
{
    //this is where we put the various variables that will need to be tracked
    public float experience;
    public int level;
    public int attemptCount;
    public bool isTutorialComplete;


}
