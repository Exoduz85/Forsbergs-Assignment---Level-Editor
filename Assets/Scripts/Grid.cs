using UnityEngine;

public class Grid{
    private int _width;
    private int _height;
    private int[,] _gridArray;
    private float _gridOffset;
    private Vector3 _gridOrigin = Vector3.zero;
    private Transform _parent;

    public Grid(int width, int height, float gridOffset, Transform parent){
        this._width = width;
        this._height = height;
        this._gridOffset = gridOffset;
        this._parent = parent;
    }

    public void CreateGrid(){
        _gridArray = new int[_width,_height];
    }

    public void PopulateGrid(){
        for (int x = 0; x < _gridArray.GetLength(0); x++){
            for (int y = 0; y < _gridArray.GetLength(1); y++){
                Vector3 positionToSpawn = new Vector3(x * _gridOffset, y * _gridOffset) + _gridOrigin;
                Tile grassTile = new Tile("Grass", positionToSpawn, Color.green, _parent);
                grassTile.CreateTile();
            }
        }
    }
}
