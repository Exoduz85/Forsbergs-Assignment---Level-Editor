using System;
using UnityEngine;
using UnityEngine.UI;

public class Painter : MonoBehaviour
{
    private TileTypeLib tileTypeLib;
    private void Start(){
        this.transform.name = this.transform.name.Replace("(Clone)", "");
        tileTypeLib = GameObject.Find("Grid").gameObject.GetComponent<TileTypeLib>();
        // will this add a listener every time i press the button?
        this.transform.gameObject.GetComponent<Button>().onClick.AddListener(SetCorrectTileType);
    }
    public void SetCorrectTileType(){
        tileTypeLib.SetSelectedType(this.name);
        this.transform.gameObject.GetComponent<Button>().onClick.RemoveListener(SetCorrectTileType);
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
            if (hitPoint.collider.gameObject.GetComponent<Tile>()){
                hitPoint.collider.gameObject.GetComponent<Tile>().SetTileType(tileTypeLib.Selected);
            }
        }
    }
}
