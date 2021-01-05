using UnityEngine;
public class TileType{
    public Color _color;
    public string _name;
    public Transform _parent;

    public TileType(Color color, string name, Transform parent){
        this._color = color;
        this._name = name;
        this._parent = parent;
    }
}
