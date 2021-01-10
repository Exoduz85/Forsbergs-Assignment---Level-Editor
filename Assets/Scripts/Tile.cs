using UnityEngine;
[System.Serializable]
public class Tile : MonoBehaviour{
    public TileType TileType;
    public void SetPosition(float x, float y){
        this.transform.position = new Vector3(x, y);
    }
    public void SetTileType(TileType tileType){
        this.TileType = tileType;
        this.transform.GetComponent<SpriteRenderer>().color = this.TileType.color;
        this.transform.name = this.TileType.name;
    }
}