using UnityEngine;

public class Tile{
    public GameObject CreateTile(Color color, string name){
        GameObject newTile = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newTile.GetComponent<Renderer>().material.color = color;
        newTile.name = name;
        return newTile;
    }
}

public class foo : MonoBehaviour{
    public void CreateNewTile(){
        Tile tile = new Tile();
        GameObject go = tile.CreateTile(Color.black, "test");
    }
}
