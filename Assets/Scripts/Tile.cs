using UnityEngine;

public class Tile : MonoBehaviour{
    public TileType tileType;
    public void SetPosition(float x, float y){
        this.transform.position = new Vector3(x, y);
    }
    public void SetTileType(TileType tileType){
        this.tileType = tileType;
        this.transform.GetComponent<SpriteRenderer>().color = this.tileType.color;
        this.transform.name = this.tileType.name;
    }
}