using UnityEngine;
using System.Collections;

public class EnemyBullet_1 : MonoBehaviour {
    
    // Use this for initialization
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "bullet" || target.tag == "Player")
        {
            //SoundsManager.instance.playEnemyDeadClip();
            Destroy(this.gameObject);
            //GamePlayController.instance.planeDieShowPanel ();
        }
        

        if (target.tag == "ground")
        {
            Destroy(this.gameObject);
        }


    }
}
