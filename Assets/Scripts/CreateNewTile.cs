using UnityEngine;
using UnityEngine.UI;

public class CreateNewTile : MonoBehaviour{

    private TileType TileType;
    public void CreateTile(Button onClickButton){
        TileType = new TileType(onClickButton.GetComponent<Image>().color, onClickButton.name, this.transform);
        TileTypeLib selected = new TileTypeLib(); // how to work with this???
        selected.Selected = TileType;
    }
    private void Update(){
        if (Input.GetMouseButtonDown(0)){
            PlaceTile(TileType);
        }
        if (Input.GetMouseButton(1)){
            PlaceTile(TileType);
        }
    }
    private void PlaceTile(TileType tileType){
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPoint;
        if (Physics.Raycast(mouseRay, out hitPoint, 100f)){
            if (tileType != null){
                if (tileType._name != hitPoint.collider.gameObject.name){
                    Tile tile = new Tile(hitPoint.collider.transform.position, tileType._parent, tileType); 
                    tile.CreateTile();
                    Destroy(hitPoint.collider.gameObject);
                }
            }
        }
    }
}
