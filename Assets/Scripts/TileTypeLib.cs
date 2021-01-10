using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class TileTypeLib : MonoBehaviour{
    public TileType Selected;
    public TileType Default;
    public TileType[] All;
    public Button associatedButton;
    public List<TileType> tileTypes;
    private TileType[] jsonArray;
    private const string tileTypesList = "TileTypesList";
    private void Awake(){
        
        if (!PlayerPrefs.HasKey(tileTypesList)){
            this.tileTypes = new List<TileType>();
            this.tileTypes.Add(new TileType("Grass", Color.green));
            this.tileTypes.Add(new TileType("Water", Color.blue));
            this.tileTypes.Add(new TileType("Clear", Color.clear));
            this.Default = new TileType("Default", Color.white);
            this.tileTypes.Add(this.Default);
        }
        else{
            jsonArray = JsonHelper.FromJson<TileType>(PlayerPrefs.GetString(tileTypesList));
            tileTypes = jsonArray.ToList();
        }
    }
    public TileType GetByName(string name){
        var match = tileTypes.Find(x => x.name.Contains(name));
        if (match == null){
            return this.Default;
        }
        return match;
    }
    public void SetSelectedType(string name, Button button){
        this.Selected = this.GetByName(name);
        this.associatedButton = button;
    }

    public void RenameTileType(PainterButton painterButton,string name){
        TileType tileType = GetByName(painterButton.name);
        tileTypes.Remove(tileTypes.Find(x => x.name.Contains(tileType.name)));
        tileType.name = name;
        tileTypes.Add(tileType);
    }

    public void RecolorTileType(PainterButton painterButton, Color color){
        TileType tileType = GetByName(painterButton.name);
        tileTypes.Remove(tileTypes.Find(x => x.name.Contains(tileType.name)));
        tileType.color = color;
        tileTypes.Add(tileType);
    }
    private void OnApplicationQuit(){
        string tileDataToJson = JsonHelper.ToJson(tileTypes.ToArray());
        PlayerPrefs.SetString(tileTypesList, tileDataToJson);
    }
}