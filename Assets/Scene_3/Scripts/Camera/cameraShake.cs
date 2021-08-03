using UnityEngine;
using System.Collections;

public class cameraShake : MonoBehaviour {

	public static cameraShake instance;

	private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay;
	public float shake_intensity;

	void Awake() {

		if (instance == null) {
			instance = this;
		}

		originPosition = transform.position;
		originRotation = transform.rotation;
	}

	//void OnGUI (){
	//	if (GUI.Button (new Rect (20,40,80,20), "Shake")){
	//		Shake ();
	//	}
	//}

	void Update (){
		if (shake_intensity > 0) {
			transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
			transform.rotation = new Quaternion (
				originRotation.x + Random.Range (-shake_intensity, shake_intensity) * .2f,
				originRotation.y + Random.Range (-shake_intensity, shake_intensity) * .2f,
				originRotation.z + Random.Range (-shake_intensity, shake_intensity) * .2f,
				originRotation.w + Random.Range (-shake_intensity, shake_intensity) * .2f);
			shake_intensity -= shake_decay;
		} else {
			transform.position = originPosition;
			transform.rotation = originRotation;
		}
	}

	public void Shake(){
		shake_intensity = .1f;
		shake_decay = 0.01f;
	}

}
