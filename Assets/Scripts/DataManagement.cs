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
        FileStream file = new File.Create(Application.persistentDataPath + "/gameInfo.dat");


    }

    public void LoadData() {

    }

}
