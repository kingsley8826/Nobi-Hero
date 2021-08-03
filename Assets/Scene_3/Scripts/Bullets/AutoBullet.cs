using UnityEngine;
using System.Collections;

public class AutoBullet : MonoBehaviour {

	public float speed;

	private Rigidbody2D body;

	Transform target;
	[SerializeField]
	public GameObject explosionAnimation;

	private Vector2 vector;

	private float targetX;
	private float targetY;



	void Awake() {
		body = GetComponent<Rigidbody2D> ();
	}

	void Start() {
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			target = GameObject.FindGameObjectWithTag ("Player").transform;
			vector = (target.position - transform.position).normalized * speed;
		} else {
			vector = new Vector2 (-speed, 0);
		}
	}

	void Update() {
		body.velocity = vector;
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "ground" || target.tag == "bullet" || target.tag == "Player" || target.tag == "UtilBullet" || target.tag == "PlayerBullet3") {
			Destroy (this.gameObject);
			playExplosion ();
			Sound.instance.playEnemyDeadClip();
		}
	}
	void playExplosion() {
		GameObject explosion = (GameObject)Instantiate (explosionAnimation);
		explosion.transform.position = transform.position;
	}
}
