using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public class CreateGrid : MonoBehaviour{
    public int ySize;
    public int xSize;
    private int[,] gridArray;
    public float gridOffset = 1f;
    public Vector3 gridOrigin = Vector3.zero;
    public GameObject starterTile;
    public GameObject emptyTile;
    public GameObject grassTile;
    public GameObject waterTile;
    private GameObject drawTile;
    void Start(){
        this.gridArray = new int[xSize,ySize];
        PopulateGrid();
        this.transform.position = new Vector3(xSize * -0.5f, ySize * -0.5f, 0);
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
            if (drawTile != null){
                if (drawTile.name != hitPoint.collider.gameObject.name){
                    var newClone = Instantiate(drawTile, hitPoint.collider.transform.position,
                        hitPoint.collider.transform.rotation, transform);
                    newClone.name = drawTile.name;
                    Destroy(hitPoint.collider.gameObject);
                }
            }
        }
    }
    void PopulateGrid(){
        for (int x = 0; x < gridArray.GetLength(0); x++){
            for (int y = 0; y < gridArray.GetLength(1); y++){
                Vector3 positionToSpawn = new Vector3(x * gridOffset, y * gridOffset) + gridOrigin;
                    if (x > gridArray.GetLength(0) * 0.5f - 5&& x < gridArray.GetLength(0) * 0.5f + 5 &&
                    y > gridArray.GetLength(1) * 0.5f - 5 && y < gridArray.GetLength(1) * 0.5f + 5)
                        SpawnClone(positionToSpawn, Quaternion.identity, starterTile, starterTile.name);
                    else 
                        SpawnClone(positionToSpawn, Quaternion.identity, emptyTile, emptyTile.name);
            }
        }
    }
    private void SpawnClone(Vector3 positionToSpawn, Quaternion rotationToSpawn, GameObject prefabToSpawn, string name){
        GameObject clone = Instantiate(prefabToSpawn, positionToSpawn, rotationToSpawn);
        clone.transform.SetParent(this.transform);
        clone.name = name;
    }
    public void SelectWaterTile(){
        this.drawTile = this.waterTile;
    }
    public void SelectGrassTile(){
        this.drawTile = this.grassTile;
    }
    public void ResetGrid(){
        foreach (Transform child in this.transform){
            Destroy(child.gameObject);
        }
        this.transform.position = Vector3.zero;
        PopulateGrid();
        this.transform.position = new Vector3(xSize * -0.5f, ySize * -0.5f, 0);
    }
    private Save CreateNewMapSave(){
        Save save = new Save();
        foreach (Transform child in this.transform){
            save.xPositions.Add(child.transform.position.x);
            save.yPositions.Add(child.transform.position.y);
            save.tileNames.Add(child.name);
        }
        return save;
    }
    public void SaveMap(){
        Save save = CreateNewMapSave();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/SavedMaps/SavedMap.save");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Game Saved!");
    }
    public void LoadSavedMap(){
        
        if (File.Exists(Application.dataPath + "/SavedMaps/SavedMap.save")){
            foreach (Transform child in this.transform){
                Destroy(child.gameObject);
            }
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/SavedMaps/SavedMap.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
            for (int i = 0; i < save.xPositions.Count; i++){
                Vector3 tilePosition = new Vector3(save.xPositions[i], save.yPositions[i], 0);
                string tileName = save.tileNames[i];
                GameObject instance = Resources.Load(tileName, typeof(GameObject)) as GameObject;
                SpawnClone(tilePosition, Quaternion.identity, instance, tileName);
            }
            Debug.Log("Map loaded!");
        }
        else Debug.Log("No map saved!");
    }

    public void EditExistingTileType(){
        // Edit the existing tiles colors and names..
    }
}
