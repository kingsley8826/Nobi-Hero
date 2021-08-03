using UnityEngine;
using System.Collections;

public class BGScaler2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float backgroundHeight = Camera.main.orthographicSize * 2f;
        float backgroundWidth = backgroundHeight * Screen.width / Screen.height;

        transform.localScale = new Vector3(backgroundWidth, backgroundHeight, 0f);
    }
}
