using UnityEngine;
using UnityEngine.UI;

public class CreateNewTile : MonoBehaviour{

    private string TileType;
    private Color buttonColor;
    public void CreateTile(Button onClickButton){
        TileType = onClickButton.name;
        buttonColor = onClickButton.image.material.color;
    }
    private void Update(){
        if (Input.GetMouseButtonDown(0)){
            PlaceTile(TileType, buttonColor);
        }
        if (Input.GetMouseButton(1)){
            PlaceTile(TileType, buttonColor);
        }
    }
    private void PlaceTile(string tileType, Color color){
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPoint;
        if (Physics.Raycast(mouseRay, out hitPoint, 100f)){
            if (tileType != null){
                if (tileType != hitPoint.collider.gameObject.name){
                    Tile tile = new Tile(tileType, hitPoint.collider.transform.position, color, this.transform); 
                    tile.CreateTile();
                    Destroy(hitPoint.collider.gameObject);
                }
            }
        }
    }
}
