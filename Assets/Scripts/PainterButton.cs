using UnityEngine;
[System.Serializable]
public class PainterButton{
    public string name;
    public Color buttonColor;
    public string displayText;
    public PainterButton(string name, string displayText, Color color){
        this.name = name;
        this.buttonColor = color;
        this.displayText = displayText;
    }
}