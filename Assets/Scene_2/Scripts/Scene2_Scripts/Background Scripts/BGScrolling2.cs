using UnityEngine;
using System.Collections;

public class BGScrolling2 : MonoBehaviour {

    public float scrollSpeed;
    private Material material;
    private Vector2 offset = Vector2.zero;

    void Awake(){
        material = GetComponent<Renderer>().material;

    }
	// Use this for initialization
	void Start () {
        offset = material.GetTextureOffset("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {
        offset.x += scrollSpeed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
	}
}
