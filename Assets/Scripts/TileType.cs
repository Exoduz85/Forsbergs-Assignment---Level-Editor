using UnityEngine;
using UnityEngine.UI;

public class TileType{
    private Color _color;
    private string _name;
    private Transform _parent;

    public TileType(Color color, string name, Transform parent){
        this._color = color;
        this._name = name;
        this._parent = parent;
    }
    public void CreateNewTileType(){
        GameObject newTileType = new GameObject();
        newTileType.AddComponent<CanvasRenderer>();
        newTileType.AddComponent<Image>();
        newTileType.AddComponent<Button>();
        newTileType.GetComponent<Image>().color = _color;
        newTileType.name = _name;
        newTileType.transform.parent = _parent;
    }
}
