using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	[SerializeField]
	public Transform player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector3 temp = transform.position;
		temp.x = player.position.x;
		transform.position = temp;
	}
}
