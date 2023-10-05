using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance; //Really, this should be called DataManager, but alas

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save() //SaveData method
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData data = new PlayerData();

        //apply current info to save data below. IE: data.health = health

        //finishes the writing and closes the file
        bf.Serialize(file, data);
        file.Close();

    }

    public void loadSave() //loadSaveData method
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            //apply saved data info below. IE: health = data.health
        }
    }
}

//class exists to be a place where I can serialize the data pertinent to the player's progression;
[Serializable]
class PlayerData
{
    //this is where we put the various variables that will need to be tracked

}
