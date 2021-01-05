using UnityEngine;

public class Tile{
    private Vector3 _position;
    private Transform _parent;
    private readonly TileType _tileType;

    public Tile(Vector3 position, Transform parent, TileType tileType){
        this._position = position;
        this._parent = parent;
        _tileType = tileType;
    }
    public void CreateTile(){
        GameObject newTile = Resources.Load("DefaultTile", typeof(GameObject)) as GameObject;
        var tile = GameObject.Instantiate(newTile, _position, Quaternion.identity);
        tile.GetComponent<SpriteRenderer>().color = _tileType._color;
        tile.name = _tileType._name;
        tile.transform.parent = _parent;
    }
}