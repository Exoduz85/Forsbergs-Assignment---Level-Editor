using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class SetupPainterButtons : MonoBehaviour{
    public List<PainterButton> PainterButtons;
    private PainterButton defaultButton;
    private PainterButton[] jsonArray;
    public Transform parent;
    public Transform grid;
    private const string buttonsKey = "ButtonsList";
    void Awake()
    {
        defaultButton = new PainterButton("Default","Default", Color.white);
        if (PlayerPrefs.HasKey(buttonsKey)){
            jsonArray = JsonHelper.FromJson<PainterButton>(PlayerPrefs.GetString(buttonsKey));
            PainterButtons = jsonArray.ToList();
        }
        else{
            PainterButtons.Add(new PainterButton("Grass", "Grass", Color.green));
            PainterButtons.Add(new PainterButton("Water", "Water", Color.blue));
        }
        foreach (PainterButton painterButton in PainterButtons){
            if (painterButton != null){
                SpawnPainterButton(painterButton);
            }
        }
    }
    private void SpawnPainterButton(PainterButton painterButton){
        GameObject button = Instantiate(new GameObject(), parent, true);
        GameObject textObject = Instantiate(new GameObject(), button.transform, true);
        button.AddComponent<Button>();
        button.AddComponent<Image>();
        button.AddComponent<Painter>();
        button.GetComponent<Image>().color = painterButton.buttonColor;
        button.name = painterButton.name;
        textObject.AddComponent<Text>();
        textObject.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        textObject.GetComponent<Text>().text = painterButton.displayText;
        textObject.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        textObject.GetComponent<Text>().resizeTextForBestFit = true;
        textObject.GetComponent<Text>().color = Color.black;
    }
    public void CreateNewButton(){
        PainterButton newButton = new PainterButton("New Painter Button", "New", Color.white);
        PainterButtons.Add(newButton);
        grid.GetComponent<TileTypeLib>().tileTypes.Add(new TileType("New Painter Button", Color.white));
        SpawnPainterButton(newButton);
    }
    public PainterButton GetByName(string name){
        var match = PainterButtons.Find(x => x.name.Contains(name));
        if (match == null){
            return this.defaultButton;
        }
        return match;
    }
    public void ChangeExistingPainterButtonColor(PainterButton painterButton, Color color){
        grid.GetComponent<TileTypeLib>().RecolorTileType(painterButton, color); //null because grid is set to inactive.
        PainterButtons.Remove(PainterButtons.Find(x => x.name.Contains(painterButton.name)));
        painterButton.buttonColor = color;
        PainterButtons.Add(painterButton);
    }
    public void ChangeExistingPainterButtonName(PainterButton painterButton, string name){
        grid.GetComponent<TileTypeLib>().RenameTileType(painterButton, name); //null because grid is set to inactive.
        PainterButtons.Remove(PainterButtons.Find(x => x.name.Contains(painterButton.name)));
        painterButton.name = name;
        painterButton.displayText = name;
        PainterButtons.Add(painterButton);
    }
    private void OnApplicationQuit(){
        string dataToJson = JsonHelper.ToJson(PainterButtons.ToArray());
        PlayerPrefs.SetString(buttonsKey, dataToJson);
    }
}