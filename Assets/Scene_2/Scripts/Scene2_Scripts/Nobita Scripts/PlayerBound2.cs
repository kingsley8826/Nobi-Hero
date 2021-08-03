using UnityEngine;
using System.Collections;

public class PlayerBound2 : MonoBehaviour {

    private float minX, maxX, minY, maxY;
	// Use this for initialization
	void Start () {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        minX = -bounds.x + 0.6f;
        maxX = bounds.x - 0.7f;
        minY = -bounds.y + 1f;
        maxY = bounds.y - 0.6f;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = transform.position;
        if(temp.x < minX){
            temp.x = minX;
        }else if(temp.x > maxX){
            temp.x = maxX;
        }
        if (temp.y < minY){
            temp.y = minY;
        }else if (temp.y > maxY){
            temp.y = maxY;
        }
        transform.position = temp;
    }
}
