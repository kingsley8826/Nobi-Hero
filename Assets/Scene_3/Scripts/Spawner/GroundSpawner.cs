using UnityEngine;
using System.Collections;

public class GroundSpawner : MonoBehaviour {

	[SerializeField]
	public GameObject land;
	[SerializeField]
	public GameObject longLand;

	private BoxCollider2D box;

	void Awake() {
		box = GetComponent<BoxCollider2D> ();
	}	

	// Use this for initialization
	void Start () {
		StartCoroutine (spawnerGround ());
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator spawnerGround() {
		Vector3 temp = transform.position;
		var minY = -box.bounds.size.y / 2f;
		var maxY = box.bounds.size.y / 2f;
		temp.y += Random.Range (minY, maxY);

		if (EnemySpawner.instance.finalBoss) {
			temp.y = -3.5f;
			GameObject ground = (GameObject)Instantiate(longLand, temp, Quaternion.identity);
			//Transform target = GameObject.FindGameObjectWithTag ("boss").transform;
			yield return new WaitForSeconds (5f);
			ground.GetComponent<AutoMove> ().speedConstant = 0;
			GameObject.FindGameObjectWithTag ("BGQuad").GetComponent<BGScripts> ().scrollSpeed = 0;
		} else {
			Instantiate(longLand, temp, Quaternion.identity);
			yield return new WaitForSeconds (Random.Range(5.1f,5.9f));
			StartCoroutine (spawnerGround ());
		}
	}
}
