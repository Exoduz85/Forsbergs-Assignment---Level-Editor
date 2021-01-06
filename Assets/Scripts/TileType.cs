using UnityEngine;
public class TileType{
    public Color color;
    public string name;
    public Transform parent;

    public TileType(Color color, string name, Transform parent){
        this.color = color;
        this.name = name;
        this.parent = parent;
    }

    public TileType(){
        
    }

    public TileType ReturnGrassType(Transform parent){
        this.color = Color.green;
        this.name = "Grass";
        this.parent = parent;
        return this;
    }
    public TileType ReturnWaterType(Transform parent){
        this.color = Color.blue;
        this.name = "Water";
        this.parent = parent;
        return this;
    }
    public TileType ReturnEmptyType(Transform parent){
        this.color = Color.clear;
        this.name = "Empty";
        this.parent = parent;
        return this;
    }
}
