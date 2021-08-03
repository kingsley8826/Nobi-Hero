using UnityEngine;
using System.Collections;

public class AutoMove : MonoBehaviour {

	public float speedConstant;

	void Awake() {
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 vel = transform.position;
		vel.x -= speedConstant;
		transform.position = vel;
	}
}
