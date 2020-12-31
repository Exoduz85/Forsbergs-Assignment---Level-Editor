using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[Serializable]
public class ColorEvent : UnityEvent<Color>{ }

public class ColorPicker : MonoBehaviour{
    public GameObject SelectedTile;
    public GameObject grassTile;
    public GameObject waterTile;
    public GameObject gridView;
    public RectTransform rect;
    private Texture2D colorTexture;
    public Image colorPicker;
    public Color color;

    public ColorEvent OnColorPreview;
    public ColorEvent OnColorSelect;
    void Start()
    {
        colorTexture = colorPicker.GetComponent<Image>().mainTexture as Texture2D;
    }
    void Update(){
        Vector2 delta;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, Input.mousePosition, null, out delta);

        float width = rect.rect.width;
        float height = rect.rect.height;
        delta += new Vector2(width * 0.5f, height * 0.5f);
        
        float x = Mathf.Clamp(delta.x / width, 0f, 1f);
        float y = Mathf.Clamp(delta.y / height, 0f, 1f);

        int textureX = Mathf.RoundToInt(x * colorTexture.width);
        int textureY = Mathf.RoundToInt(y * colorTexture.height);
        
        color = colorTexture.GetPixel(textureX, textureY);
        
        Vector2 localMousePosition = rect.InverseTransformPoint(Input.mousePosition);

        if (rect.rect.Contains(localMousePosition)){
            OnColorPreview?.Invoke(color);
            if (Input.GetMouseButtonDown(0)){
                OnColorSelect?.Invoke(color);
            }
        }
    }

    public void SelectGrassTile(){
        SelectedTile = grassTile;
    }
    public void SelectWaterTile(){
        SelectedTile = waterTile;
    }

    public void ChangeColor(){
        SelectedTile.gameObject.GetComponent<Renderer>().sharedMaterial.color = color;
    }

    public void CloseWindow(){
        this.transform.gameObject.SetActive(false);
        gridView.SetActive(true);
    }
}