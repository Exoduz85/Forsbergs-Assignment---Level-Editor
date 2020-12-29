using UnityEngine;

public class MoveCamera : MonoBehaviour{

    public float speed = 10;
    public float screenWidth = Screen.width;
    public float screenHeight = Screen.height;
    private void Start(){
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }
    private void Update(){
        if (Input.mousePosition.x > screenWidth * 0.8f){
            transform.position += Vector3.right * (speed * Time.deltaTime);
        }
        else if (Input.mousePosition.x < screenWidth * 0.2f){
            transform.position += Vector3.left * (speed * Time.deltaTime);
        } 
        if (Input.mousePosition.y > screenHeight * 0.8f){
            transform.position += Vector3.up * (speed * Time.deltaTime);
        }
        else if (Input.mousePosition.y < screenHeight * 0.2f){
            transform.position += Vector3.down * (speed * Time.deltaTime);
        }
    }
}
