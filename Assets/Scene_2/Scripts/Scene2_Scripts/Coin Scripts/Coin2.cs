using UnityEngine;
using System.Collections;

public class Coin2 : EnemyBullet2{
	[SerializeField]
	GameObject smallCoin;

    public override void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player" || target.tag == "KillerLeft" )
        {
            Destroy(gameObject);			
        }
        if(target.tag == "Player")
        {
            Instantiate(smallCoin, target.transform.position, Quaternion.identity);
        }
    }
}
