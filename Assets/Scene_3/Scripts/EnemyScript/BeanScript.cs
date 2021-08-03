using UnityEngine;
using System.Collections;

public class BeanScript : MonoBehaviour {

	public float speed;
	public float blood = 2;

	private Rigidbody2D body;

	[SerializeField]
	public GameObject explosionDead;
	[SerializeField]
	public GameObject explosionHitBullet;

    [SerializeField]
    public GameObject BulletDameItem;
    [SerializeField]
    public GameObject NumBulletItem;
    [SerializeField]
    public GameObject inBloodItem;
    public int itemType;

    void Awake() {
		body = GetComponent<Rigidbody2D> ();
        itemType = Random.Range(1, 20);
    }


	void FixedUpdate() {
		Vector2 temp = body.velocity;
		temp.x = -speed;
		body.velocity = temp;
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D target) {

		if (target.tag == "UtilBullet") {
			blood = 0;
		}
		if (target.tag == "bullet") {
			blood -= 1f;
			if (blood != 0) {
				playExplosionHitBullet();
			}
		}

		if (target.tag == "PlayerBullet3") {
			blood -= 2f;
		}
		if (target.tag == "Player") {
			GetComponent<BoxCollider2D> ().isTrigger = true;
			body.isKinematic = true;
			speed = 0;
			Vector3 temp = transform.localScale;
			temp.x = -temp.x;
			transform.localScale = temp;
			Sound.instance.playBeanExplosionClip ();
			StartCoroutine (changeState ());
		}
		if (blood <= 0) {
			Destroy (this.gameObject);
			playExplosion();
			cameraShake.instance.Shake();
			Vector3 temp2 = transform.position;
			if (itemType == 1 || itemType == 2)
			{
				Instantiate(NumBulletItem, temp2, Quaternion.identity);
			}
			else if (itemType == 3)
			{
				Instantiate(BulletDameItem, temp2, Quaternion.identity);
			}
			else if (itemType == 5 || itemType == 6 || itemType == 4 )
			{
				Instantiate(inBloodItem, temp2, Quaternion.identity);
			}
		}
			
	}

	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Player") {
		}
	}

	IEnumerator changeState() {
		this.blood = 0;
		Renderer renderer = GetComponent<Renderer> ();
		renderer.material.color = new Color (1, 0, 0);
		yield return new WaitForSeconds (0.1f);
		renderer.material.color = new Color (0, 0, 0);
		yield return new WaitForSeconds (0.1f);
		renderer.material.color = new Color (1, 1, 0);
		playExplosion ();
	}

	void playExplosion() {
		GameObject explosion = (GameObject)Instantiate (explosionDead);
		Vector3 temp = transform.position;
		//temp.x += 1;
		explosion.transform.position = temp;
	}
	void playExplosionHitBullet() {
		GameObject explosion = (GameObject)Instantiate (explosionHitBullet);
		Vector3 temp = transform.position;
		//temp.x += 1;
		explosion.transform.position = temp;
	}
}
