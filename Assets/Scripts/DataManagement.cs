using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel.Design;

public class DataManagement : MonoBehaviour {

    public static DataManagement dataManagement;

    public int highScore;

    void Awake() {

        if(dataManagement == null) {
            DontDestroyOnLoad(gameObject);
            dataManagement = this;
        }
        else if(dataManagement != this) {
            Destroy(gameObject);
        }

    }

    public void SaveData() {

        BinaryFormatter binForm = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");
        GameData data = new GameData();
        data.highScore = this.highScore;
        binForm.Serialize(file, data);
        file.Close();

    }

    public void LoadData() {

        if(File.Exists(Application.persistentDataPath + "/gameInfo.dat")) {
            BinaryFormatter binForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            GameData data = (GameData)binForm.Deserialize(file);
            file.Close();
            this.highScore = data.highScore;
        }


    }

}

[Serializable]
class GameData {

    public int highScore;

}
