using UnityEngine;

public class Tile{
    private string _name;
    private Vector3 _position;
    private Color _color;
    private Transform _parent;

    public Tile(string name, Vector3 position, Color color, Transform parent){
        this._name = name;
        this._position = position;
        this._color = color;
        this._parent = parent;
    }

    // method should maybe instead take the position, name, color and parent?
    public void CreateTile(){
        GameObject newTile = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newTile.transform.position = _position;
        Material newMaterial = new Material(Shader.Find("Unlit/Color"));
        newTile.gameObject.GetComponent<MeshRenderer>().material = newMaterial;
        newMaterial.color = _color;
        newTile.name = _name;
        newTile.transform.parent = _parent;
    }
}
