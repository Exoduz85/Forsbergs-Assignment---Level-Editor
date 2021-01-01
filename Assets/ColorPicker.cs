using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[Serializable]
public class ColorEvent : UnityEvent<Color>{ }

// TODO Redo this script so that it can work with the new tile and grip script.
public class ColorPicker : MonoBehaviour{
    public GameObject gridView;
    public RectTransform rect;
    private Texture2D _colorTexture;
    public Image colorPicker;
    public Color color;
    private string _tileType;
    private Color _onButtonColor;
    public ColorEvent OnColorPreview;
    public ColorEvent OnColorSelect;
    void Start()
    {
        _colorTexture = colorPicker.GetComponent<Image>().mainTexture as Texture2D;
    }
    void Update(){
        Vector2 delta;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, Input.mousePosition, null, out delta);

        float width = rect.rect.width;
        float height = rect.rect.height;
        delta += new Vector2(width * 0.5f, height * 0.5f);
        
        float x = Mathf.Clamp(delta.x / width, 0f, 1f);
        float y = Mathf.Clamp(delta.y / height, 0f, 1f);

        int textureX = Mathf.RoundToInt(x * _colorTexture.width);
        int textureY = Mathf.RoundToInt(y * _colorTexture.height);
        
        color = _colorTexture.GetPixel(textureX, textureY);
        
        Vector2 localMousePosition = rect.InverseTransformPoint(Input.mousePosition);

        if (rect.rect.Contains(localMousePosition)){
            OnColorPreview?.Invoke(color);
            if (Input.GetMouseButtonDown(0)){
                OnColorSelect?.Invoke(color);
            }
        }
    }
    
    public void SelectTile(Button onClickButton){
        _tileType = onClickButton.name;
        onClickButton.image.material.color = _onButtonColor;
    }

    public void ChangeColor(){
        _onButtonColor = color; // need to change the buttons runtime color also.
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