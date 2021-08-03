using UnityEngine;
using System.Collections;

public class PlayerBullet2 : Bullet2 {

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "KillerLeft" || target.tag == "KillerRight" ||
            target.tag == "Enemy" || target.tag == "Boss" ||
            target.tag == "GrayBullet" || target.tag == "BossBullet")
        {
            Destroy(gameObject);
        }

		if (target.tag == "Enemy" || target.tag == "Boss" ||
			target.tag == "GrayBullet" || target.tag == "BossBullet") {
			Sound.instance.playEnemyDeadClip ();
		}
    }
}
