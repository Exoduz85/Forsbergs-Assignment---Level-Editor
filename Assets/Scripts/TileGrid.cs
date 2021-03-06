﻿using UnityEngine;
using UnityEngine.UI;
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
    public void EditTileTypeColor(Color color){
        this.TileTypeLib.Selected.color = color;
        this.TileTypeLib.associatedButton.GetComponent<Image>().color = color;
        ChangeExistingTiles();
    }
    public void ChangeExistingTiles(){
        foreach (var tile in this.tiles){
            if (tile.TileType == this.TileTypeLib.Selected){
                tile.SetTileType(this.TileTypeLib.Selected);
            }
        }
    }
}
