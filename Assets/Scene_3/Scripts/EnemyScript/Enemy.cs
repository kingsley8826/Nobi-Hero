using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed;

	public float blood = 2;

	private Rigidbody2D body;
	[SerializeField]
	public GameObject bullet;

	[SerializeField]
	public GameObject explosionDead;

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

	// Use this for initialization
	void Start () {
		StartCoroutine (shoot ());
	}

	IEnumerator shoot() {
		Vector3 temp = transform.position;
		temp.x -= 0.3f;
		Sound.instance.playEnemyShootClip ();
		Instantiate (bullet, temp, Quaternion.identity);
		yield return new WaitForSeconds (Random.Range (4f, 5f));
		StartCoroutine (shoot ());
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D target) {

		if (target.tag == "bullet" || target.tag == "Player" || target.tag == "UtilBullet") {
			playExplosion ();
		}

		if (target.tag == "bullet") {
			blood -= 1f;
		}

		if (target.tag == "PlayerBullet3") {
			blood -= 2f;
		}

		if (target.tag == "Player") {
            Sound.instance.playEnemyDeadClip();
			blood = 0;
			//Destroy (target.gameObject);
			//GamePlayController.instance.planeDieShowPanel ();
		}
		if (target.tag == "Border") {
			//Destroy (this.gameObject);
		}
		if (blood <= 0) {
			Destroy (this.gameObject);
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



	void playExplosion() {
		GameObject explosion = (GameObject)Instantiate (explosionDead);
		explosion.transform.position = transform.position;
	}
}
