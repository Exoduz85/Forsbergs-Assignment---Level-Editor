using UnityEngine;

public class Grid{
    private int width;
    private int height;
    private int[,] gridArray;
    private float gridOffset;
    private Vector3 gridOrigin = Vector3.zero;
    private Transform parent;
    public Grid(int width, int height, float gridOffset, Transform parent){
        this.width = width;
        this.height = height;
        this.gridOffset = gridOffset;
        this.parent = parent;
    }
    public void CreateGrid(){
        gridArray = new int[width,height];
    }
    public void PopulateGrid(){
        for (int x = 0; x < gridArray.GetLength(0); x++){
            for (int y = 0; y < gridArray.GetLength(1); y++){
                Vector3 positionToSpawn = new Vector3(x * gridOffset, y * gridOffset) + gridOrigin;
                TileType tileType = new TileType();
                if (x < 10 && y < 10){
                    tileType.ReturnGrassType(this.parent);
                }
                else{
                    tileType.ReturnEmptyType(this.parent);
                }
                Tile newTile = new Tile(positionToSpawn, parent, tileType);
                newTile.CreateTile();
            }
        }
    }
}
