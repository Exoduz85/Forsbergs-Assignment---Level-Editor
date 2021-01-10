using System;
using UnityEngine;
using UnityEngine.UI;

public class Painter : MonoBehaviour
{
    public TileTypeLib tileTypeLib;
    private void Start(){
        tileTypeLib = FindObjectOfType<TileTypeLib>();
    }
    private void OnEnable(){
        this.transform.gameObject.GetComponent<Button>().onClick.AddListener(SetCorrectTileType);
    }

    public void SetCorrectTileType(){
        tileTypeLib.SetSelectedType(this.name, this.transform.gameObject.GetComponent<Button>());
    }
    private void Update(){
        if (Input.GetMouseButtonDown(0)){
            PlaceTile();
        }
        if (Input.GetMouseButton(1)){
            PlaceTile();
        }
    }
    private void PlaceTile(){
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPoint;
        if (Physics.Raycast(mouseRay, out hitPoint, 100f)){
            if (tileTypeLib.Selected != null){
                if (hitPoint.collider.gameObject.GetComponent<Tile>()){
                    hitPoint.collider.gameObject.GetComponent<Tile>().SetTileType(tileTypeLib.Selected);
                }
            }
        }
    }
}
