﻿using UnityEngine;
using UnityEngine.UI;

public class CreateNewTile : MonoBehaviour{

    private TileType TileType;
    public void CreateTile(Button onClickButton){
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
                Destroy(hitPoint.collider.gameObject);
            }
        }
    }
}
