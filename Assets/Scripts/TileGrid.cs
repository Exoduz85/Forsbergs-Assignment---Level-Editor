using UnityEngine;

public class TileGrid : MonoBehaviour{
    private Tile[,] tiles;
    public Tile tilePrefab;
    public TileTypeLib TileTypeLib;
    public int width;
    public int height;
    public float offset;

    private void Awake(){
        this.tiles = new Tile[width,height];
        for (int x = 0; x < this.width; x++){
            for (int y = 0; y < this.height; y++){
                this.tiles[x,y] = Instantiate(this.tilePrefab);
                this.tiles[x,y].SetTileType(this.TileTypeLib.GetByName("Grass"));
                this.tiles[x,y].SetPosition(x * offset, y * offset);
            }
        }
    }
}
/*
Awake()
if(!PlayerPrefs.HasKey("SavedTileGrid"))
// load initial tiles
this.tiles = new Tile[10,10];
for(var x = 0; x < 10; x++)
for(var y = 0; y < 10; y++)
this.tiles[x,y] = Instantiate(this.tilePrefab);
this.tiles[x,y].SetTileType(this.TileTypeLib.GetTileByName("Grass"));
this.tiles[x,y].SetPosition(x, y);
else
DeserializePlayerPrefs(); // needs to be implemented
*/
