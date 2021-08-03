using UnityEngine;
using System.Collections;

public class Border : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Player" || target.gameObject.tag == "bullet" || target.gameObject.tag == "honey") {
			Destroy (target.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.gameObject.tag != "ground" && target.gameObject.tag != "border") {
			Destroy (target.gameObject);
		}
	}

}
