using System.Collections.Generic;
using UnityEngine;

public class TileTypeLib : MonoBehaviour{
    public TileType Selected;
    public TileType Default;
    public TileType[] All;
    private List<TileType> TileTypes;
    private void Awake(){
        // make playerprefs save for this with json serialize and deserialize
        this.TileTypes = new List<TileType>();
        this.TileTypes.Add(new TileType("Grass", Color.green));
        this.TileTypes.Add(new TileType("Water", Color.blue));
        this.TileTypes.Add(new TileType("Clear", Color.clear));
    }
    public TileType GetByName(string name){
        var match = TileTypes.Find(x => x.name.Contains(name));
        return match;
    }

    public void SetSelectedType(string name){
        this.Selected = this.GetByName(name);
    }
}