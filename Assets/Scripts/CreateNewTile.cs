using UnityEngine;

public class CreateNewTile : MonoBehaviour{

    private TileType tileType;
    private TileTypeLib tileTypeLib;
    
    private void Update(){
        if (Input.GetMouseButtonDown(0)){
            PlaceTile(tileType);
        }
        if (Input.GetMouseButton(1)){
            PlaceTile(tileType);
        }
    }
    private void PlaceTile(TileType tileType){
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPoint;
        if (Physics.Raycast(mouseRay, out hitPoint, 100f)){
            if (tileType != null){
                Destroy(hitPoint.collider.gameObject);
            }
        }
    }
}
