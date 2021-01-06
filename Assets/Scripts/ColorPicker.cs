using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[Serializable]
public class ColorEvent : UnityEvent<Color>{ }
public class ColorPicker : MonoBehaviour{
    public GameObject gridView;
    public RectTransform rect;
    public Image colorPicker;
    public Color color;
    public InputField inputField;
    
    private Texture2D colorTexture;
    private string tileType;
    private Button button;
    private string newTileName;
    
    public ColorEvent onColorPreview;
    public ColorEvent onColorSelect;
    void Start()
    {
        colorTexture = colorPicker.GetComponent<Image>().mainTexture as Texture2D;
        inputField.onEndEdit.AddListener(delegate{LockInput(inputField);});
    }
    void Update(){
        Vector2 delta;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, Input.mousePosition, null, out delta);
        var rect1 = rect.rect;
        float width = rect1.width;
        float height = rect1.height;
        delta += new Vector2(width * 0.5f, height * 0.5f);
        
        float x = Mathf.Clamp(delta.x / width, 0f, 1f);
        float y = Mathf.Clamp(delta.y / height, 0f, 1f);

        int textureX = Mathf.RoundToInt(x * colorTexture.width);
        int textureY = Mathf.RoundToInt(y * colorTexture.height);
        
        color = colorTexture.GetPixel(textureX, textureY);
        
        Vector2 localMousePosition = rect.InverseTransformPoint(Input.mousePosition);

        if (rect.rect.Contains(localMousePosition)){
            onColorPreview?.Invoke(color);
            if (Input.GetMouseButtonDown(0)){
                onColorSelect?.Invoke(color);
            }
        }
    }
    public void SelectTile(Button onClickButton){
        tileType = onClickButton.name;
        button = onClickButton;
    }

    public void ChangeColor(){
        if (button != null){
            button.image.color = color;
            foreach (Transform child in gridView.transform){
                if (child.name == tileType){
                    child.gameObject.GetComponent<Renderer>().material.color = color;
                }
            }
        }
    }
    public void CloseWindow(){
        this.transform.gameObject.SetActive(false);
        gridView.SetActive(true);
    }

    //TODO fix so that the button object updates to their new name... and check for which placed tiles should change name...
    void LockInput(InputField input){
        if (button != null){
            if (input.text.Length > 0){
                newTileName = input.text;
                button.GetComponentInChildren<Text>().text = newTileName;
                foreach (Transform child in gridView.transform){
                    child.name = newTileName;
                }
            }
            else if (input.text.Length == 0){
                Debug.Log("Main Input Empty");
            }
        }
    }
}