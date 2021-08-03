using UnityEngine;
using System.Collections;

public class BossBullet2 : Bullet2 {

	[SerializeField]
	public GameObject explosionAnimationBullet;

    private float dame = 6;
    void Update()
    {
        if(dame <= 0)
        {
            Destroy(gameObject);
        }
    }
    public virtual void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "KillerLeft" || target.tag == "KillerRight" ||
            target.tag == "Player" || target.tag == "UtilBullet"){
            Destroy(gameObject);
        }

        if (target.tag == "PlayerBullet1")
        {
            dame -= 1.2f;
        }
        if (target.tag == "PlayerBullet2")
        {
            dame -= 1.5f;
        }
        if (target.tag == "PlayerBullet3")
        {
            dame -= 2f;
        }
		if (target.tag == "Player" || target.tag == "UtilBullet") {
			playExplosionBullet ();
		}
    }
	void playExplosionBullet() {
		GameObject explosion = (GameObject)Instantiate (explosionAnimationBullet);
		explosion.transform.position = transform.position;
		Vector2 temp = new Vector2 ();
		temp = explosion.GetComponent<Transform> ().localScale;
		temp.x = 0.8f;
		temp.y = 0.8f;
		explosion.GetComponent<Transform> ().localScale = temp;
	}
}
