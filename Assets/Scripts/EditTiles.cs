using UnityEngine;

public class EditTiles : MonoBehaviour{
    public GameObject editTileWindow;
    public void EditExistingTileType(){
        editTileWindow.SetActive(true);
        this.transform.gameObject.SetActive(false);
    }
}
