using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupPainterButtons : MonoBehaviour{
    public List<GameObject> tileTypePrefabButtons;
    public GameObject tileTypePrefabButton;
    public Transform parent;
    void Awake()
    {
        foreach (GameObject prefab in tileTypePrefabButtons){
            GameObject instance = Instantiate(prefab, parent, true);
        }
    }
    public void CreateNewButton(){
        GameObject instance = Instantiate(tileTypePrefabButton, parent, true);
        instance.transform.name = "NewPainterButton";
        instance.GetComponentInChildren<Text>().text = "New Type";
        tileTypePrefabButtons.Add(instance);
        UpdatePainterButtons();
    }

    void UpdatePainterButtons(){
        var length = tileTypePrefabButtons.Count - 1;
        var zero = 0;
        foreach (GameObject prefab in tileTypePrefabButtons){
            if (zero > length){
                GameObject instance = Instantiate(prefab, parent, true);
            }
            zero++;
        }
    }
}
