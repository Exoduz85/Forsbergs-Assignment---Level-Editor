using UnityEngine;
[System.Serializable]
public class TileType{
    public Color color;
    public string name;
    public TileType(string name, Color color){
        this.color = color;
        this.name = name;
    }
}
