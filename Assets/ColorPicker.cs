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
    
    private Texture2D _colorTexture;
    private string _tileType;
    private Button _button;
    
    public ColorEvent onColorPreview;
    public ColorEvent onColorSelect;
    void Start()
    {
        _colorTexture = colorPicker.GetComponent<Image>().mainTexture as Texture2D;
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

        int textureX = Mathf.RoundToInt(x * _colorTexture.width);
        int textureY = Mathf.RoundToInt(y * _colorTexture.height);
        
        color = _colorTexture.GetPixel(textureX, textureY);
        
        Vector2 localMousePosition = rect.InverseTransformPoint(Input.mousePosition);

        if (rect.rect.Contains(localMousePosition)){
            onColorPreview?.Invoke(color);
            if (Input.GetMouseButtonDown(0)){
                onColorSelect?.Invoke(color);
            }
        }
    }
    public void SelectTile(Button onClickButton){
        _tileType = onClickButton.name;
        _button = onClickButton;
    }
    public void ChangeColor(){
        _button.image.material.color = color; // need to change the buttons runtime color also.
        foreach (Transform child in gridView.transform){
            if (child.name == _tileType){
                child.gameObject.GetComponent<Renderer>().material.color = color;
            }
        }
    }
    public void CloseWindow(){
        this.transform.gameObject.SetActive(false);
        gridView.SetActive(true);
    }
}