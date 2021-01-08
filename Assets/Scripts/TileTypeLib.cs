using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileTypeLib : MonoBehaviour{
    public TileType Selected;
    public TileType Default;
    public TileType[] All;
    public Button associatedButton;
    private List<TileType> TileTypes;
    private void Awake(){
        // make playerprefs save for this with json serialize and deserialize
        this.TileTypes = new List<TileType>();
        this.TileTypes.Add(new TileType("Grass", Color.green));
        this.TileTypes.Add(new TileType("Water", Color.blue));
        this.TileTypes.Add(new TileType("Clear", Color.clear));
        SetDefaultTile();
    }
    public TileType GetByName(string name){
        var match = TileTypes.Find(x => x.name.Contains(name));
        if (match == null){
            return this.Default;
        }
        return match;
    }
    public void SetSelectedType(string name, Button button){
        this.Selected = this.GetByName(name);
        this.associatedButton = button;
    }
    void SetDefaultTile(){
        this.Default = new TileType("Default", Color.white);
        this.TileTypes.Add(this.Default);
    }
}