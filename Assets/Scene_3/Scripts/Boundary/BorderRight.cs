﻿using UnityEngine;
using System.Collections;

public class BorderRight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "bullet") {
			Destroy (target.gameObject);
		}
	}

}
