using UnityEngine;
using System.Collections;

public class SmallCoin : MonoBehaviour {

	public float speed;

	private Rigidbody2D body;

	Transform target;

	private Vector2 vector;

	void Awake() {
		body = GetComponent<Rigidbody2D> ();
	}

	void Start() {
		if (GameObject.FindGameObjectWithTag ("coinAvatar") != null) {
			target = GameObject.FindGameObjectWithTag ("coinAvatar").transform;
			vector = (target.position - transform.position).normalized * speed;
		}
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "coinAvatar") {
			Destroy (this.gameObject);
			//Sound.instance.playCollectionCoinClip();
		}
	}

	void Update() {
		body.velocity = vector;
	}
}
