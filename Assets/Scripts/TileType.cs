using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New tile type", menuName = "Tile Types/")]
public class TileType : ScriptableObject{
    public Color color;
    public new string name;
}
