using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour{
    public GameObject selectedTile;
    public GameObject grassTile;
    public GameObject waterTile;
    public RectTransform rect;
    public Texture2D colorTexture;
    public Image colorPicker;
    public Image previewColorImage;
    public Color color;
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
            previewColorImage.material.color = color;
        }
    }

    public void SelectGrassTile(){
        selectedTile = grassTile;
    }
    public void SelectWaterTile(){
        selectedTile = waterTile;
    }
}