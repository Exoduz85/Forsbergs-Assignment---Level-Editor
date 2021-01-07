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
    private TileTypeLib tileTypeLib;
    
    public ColorEvent onColorPreview;
    public ColorEvent onColorSelect;
    void Start()
    {
        tileTypeLib = FindObjectOfType<TileTypeLib>();
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
    public void CloseWindow(){
        this.transform.gameObject.SetActive(false);
        gridView.SetActive(true);
    }
    void LockInput(InputField input){
        if (tileTypeLib.associatedButton != null){
            if (input.text.Length > 0){
                tileTypeLib.associatedButton.GetComponentInChildren<Text>().text = input.text;
            }
            else if (input.text.Length == 0){
                Debug.Log("Main Input Empty");
            }
        }
    }
}