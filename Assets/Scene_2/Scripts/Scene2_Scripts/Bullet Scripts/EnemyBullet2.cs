using UnityEngine;
using System.Collections;

public class EnemyBullet2 : Bullet2 {

	[SerializeField]
	public GameObject explosionAnimationBullet;

    public virtual void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "KillerLeft" || target.tag == "KillerRight" ||
            target.tag == "Player" || target.tag == "UtilBullet" ||
            target.tag == "PlayerBullet1" || target.tag == "PlayerBullet2" ||
            target.tag == "PlayerBullet3")
        {
            Destroy(gameObject);
        }

		if (target.tag == "Player" || target.tag == "UtilBullet" ||
		    target.tag == "PlayerBullet1" || target.tag == "PlayerBullet2" ||
		    target.tag == "PlayerBullet3") {
			playExplosionBullet ();
		}
    }
	void playExplosionBullet() {
		GameObject explosion = (GameObject)Instantiate (explosionAnimationBullet);
		explosion.transform.position = transform.position;
		Vector2 temp = new Vector2 ();
		temp = explosion.GetComponent<Transform> ().localScale;
		temp.x = 0.6f;
		temp.y = 0.6f;
		explosion.GetComponent<Transform> ().localScale = temp;
	}
}
