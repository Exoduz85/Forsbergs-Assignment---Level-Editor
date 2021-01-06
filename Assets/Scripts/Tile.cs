using UnityEngine;

public class Tile{
    private Vector3 position;
    private Transform parent;
    private readonly TileType tileType;

    public Tile(Vector3 position, Transform parent, TileType tileType){
        this.position = position;
        this.parent = parent;
        this.tileType = tileType;
    }
    public void CreateTile(){
        GameObject newTile = Resources.Load("DefaultTile", typeof(GameObject)) as GameObject;
        var tile = GameObject.Instantiate(newTile, position, Quaternion.identity);
        tile.GetComponent<SpriteRenderer>().color = tileType.color;
        tile.name = tileType.name;
        tile.transform.parent = parent;
    }
}