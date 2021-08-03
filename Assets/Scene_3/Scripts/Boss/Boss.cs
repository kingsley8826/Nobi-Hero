using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public float speed;

	private Rigidbody2D body;
	[SerializeField]
	public GameObject bullet;

	[SerializeField]
	public GameObject explosionDead;

	public float blood;
	private Color color;

	private bool isUp = true;

	void Awake() {
		color = this.GetComponent<Renderer> ().material.color;
		body = GetComponent<Rigidbody2D> ();
	}



	void FixedUpdate() {
		Vector2 temp = body.velocity;
		if (isUp) {
			temp.y = 1f;
			if (transform.position.y > 1f)
				isUp = false;
		} else {
			temp.y = -1f;
			if (transform.position.y < 0.5f)
				isUp = true;
		}
		temp.x = -speed;
		body.velocity = temp;
	}

	void Start() {
		StartCoroutine (changeState1 ());
	}

	IEnumerator changeState1() {
		this.GetComponent<Renderer> ().material.color = color;
		yield return new WaitForSeconds (0.25f);
		if (blood <= 50 && blood > 0) {
			this.GetComponent<Renderer> ().material.color = new Color (1, 0, 0);
			yield return new WaitForSeconds (0.25f);
			this.GetComponent<Renderer> ().material.color = new Color (50, 50, 50);
			yield return new WaitForSeconds (0.15f);
		}
		StartCoroutine (changeState1());
	}

	IEnumerator changeState2() {
		this.GetComponent<Renderer> ().material.color = color;
		yield return new WaitForSeconds (0.5f);
		if ( blood > 0 && blood <= 50) {
			this.GetComponent<Renderer> ().material.color = new Color (2, 0, 0);
			yield return new WaitForSeconds (0.2f);
			StartCoroutine (changeState2());
		}
	}

	IEnumerator shoot() {
		Vector3 temp = transform.position;
		temp.x -= 0.3f;
		Sound.instance.playEnemyShootClip ();
		Instantiate (bullet, temp, Quaternion.identity);
		yield return new WaitForSeconds (Random.Range (4f, 5f));
		StartCoroutine (shoot ());
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "bullet" || target.tag == "Player" || target.tag == "PlayerBullet3") {
			playExplosion (target);
		}
		if (target.tag == "bullet") {
			blood -= 1f;
			playExplosion (target);
			Destroy (target.gameObject);
		}
		if (target.tag == "PlayerBullet3") {
			blood -= 2f;
			playExplosion (target);
			Destroy (target.gameObject);
		}
        if (target.tag == "UtilBullet")
        {
            blood -= 20f;
			playExplosion (target);
            Destroy(target.gameObject);
        }
		if (blood <= 0)
		{
			PlayerController.setOpenDoor3 ();
			int star3;
			if (GameObject.Find("GamePlay Controller").GetComponent<PlayerBlood_3>().blood >= PlayerController.maxBlood * 0.8) {
				star3 = 3;
			} else if (GameObject.Find("GamePlay Controller").GetComponent<PlayerBlood_3>().blood >= PlayerController.maxBlood * 0.5) {
				star3 = 2;
			} else if (GameObject.Find("GamePlay Controller").GetComponent<PlayerBlood_3>().blood >= PlayerController.maxBlood * 0.2) {
				star3 = 1;
			} else {
				star3 = 0;
			}
			PlayerController.setStar_lv3 (star3);

            EnemySpawner.instance.canvasSuccess.gameObject.SetActive(true);

            Debug.Log(star3);
            if (star3 == 0)
            {
                GameObject.FindGameObjectWithTag("CurrentStar").GetComponent<Animator>().SetTrigger("Rate 0");
            }
            else if (star3 == 1)
            {
                GameObject.FindGameObjectWithTag("CurrentStar").GetComponent<Animator>().SetTrigger("Rate 1");
            }
            else if (star3 == 2)
            {
                GameObject.FindGameObjectWithTag("CurrentStar").GetComponent<Animator>().SetTrigger("Rate 2");
            }
            else if (star3 == 3)
            {
                GameObject.FindGameObjectWithTag("CurrentStar").GetComponent<Animator>().SetTrigger("Rate 3");
            }

            

            Destroy(this.gameObject);
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("honey");
            foreach (GameObject go in enemys)
            {
                Destroy(go);
            }

            Destroy(this.gameObject);
            GameObject[] enemys1 = GameObject.FindGameObjectsWithTag("bean");
            foreach (GameObject go in enemys1)
            {
                Destroy(go);
            }

            GameObject[] bullets = GameObject.FindGameObjectsWithTag("honeyBullet");
            foreach (GameObject go in bullets)
            {
                Destroy(go);
            }
            GameObject spawner = GameObject.FindGameObjectWithTag("spawner3");
            if (spawner != null)
            {
                Destroy(spawner.gameObject);
            }

        }
        GameObject.Find("GamePlay Controller").GetComponent<BossBlood_3>().blood = blood;
    }

	void playExplosion(Collider2D target) {
		GameObject explosion = (GameObject)Instantiate (explosionDead);
		explosion.GetComponent<AutoMove> ().speedConstant = 0;
		if (target == null) {
			explosion.transform.position = transform.position;
		} else {
			explosion.transform.position = target.transform.position;
		}
	}

	public void playOneBullet(float extraX, float extraY) {
		if (this == null)
			return;
		Vector3 temp = transform.position;
		temp.x += extraX;
		temp.y += extraY;
		Sound.instance.playEnemyShootClip ();
		Instantiate (bullet, temp, Quaternion.identity);
	}

	public void playDoubleBullet() {
		playOneBullet (-1f, -1.5f);
		playOneBullet (-1f, +1.5f);
	}

	public void playTrippleBullet() {
		playOneBullet (-1f, -1.5f);
		playOneBullet (-1f, +0f);
		playOneBullet (-1f, +1.5f);
	}

	public void playFourBullet() {
		playOneBullet (-1f, -2f);
		playOneBullet (-1f, -1f);
		playOneBullet (-1f, +0f);
		playOneBullet (-1f, 1f);
	}

	public void playFiveBullet() {
		playOneBullet (-1f, -2f);
		playOneBullet (-1f, +1f);
		playOneBullet (-1f, +0f);
		playOneBullet (-1f, -1f);
		playOneBullet (-1f, +2f);
	}

	public void playMultiBullet() {

	}

}
