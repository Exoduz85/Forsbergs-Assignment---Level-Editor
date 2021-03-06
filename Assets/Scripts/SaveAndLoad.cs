﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public class SaveAndLoad : MonoBehaviour{ 
    private Save CreateNewMapSave(){
        Save save = new Save();
        foreach (Transform child in this.transform){
            save.xPositions.Add(child.transform.position.x);
            save.yPositions.Add(child.transform.position.y);
            save.tileNames.Add(child.name);
            float[] colors = {
                child.gameObject.GetComponent<Renderer>().material.color.r, 
                child.gameObject.GetComponent<Renderer>().material.color.g,
                child.gameObject.GetComponent<Renderer>().material.color.b,
                child.gameObject.GetComponent<Renderer>().material.color.a
            };
            save.tileColor.Add(colors);
        }
        return save;
    }
    public void SaveMap(){
        Save save = CreateNewMapSave();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/SavedMaps/SavedMap.save");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Game Saved!");
    }
    public void LoadSavedMap(){
        
        if (File.Exists(Application.dataPath + "/SavedMaps/SavedMap.save")){
            foreach (Transform child in this.transform){
                Destroy(child.gameObject);
            }
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/SavedMaps/SavedMap.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
            for (int i = 0; i < save.xPositions.Count; i++){
                Vector3 tilePosition = new Vector3(save.xPositions[i], save.yPositions[i], 0);
                string tileName = save.tileNames[i];
                float[] col = save.tileColor[i];
                Color color = new Color(col[0], col[1],col[2],col[3]);
            }
            Debug.Log("Map loaded!");
        }
        else Debug.Log("No map saved!");
    }
}
