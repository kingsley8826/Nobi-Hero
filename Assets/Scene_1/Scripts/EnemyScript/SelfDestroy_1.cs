using UnityEngine;
using System.Collections;

public class SelfDestroy_1 : MonoBehaviour {

	// Use this for initialization
	void _SelfDestroy()
    {
		//
		if (this.gameObject.tag == "Enemy" || this.gameObject.tag == "Monster")Sound.instance.playEnemyDeadClip ();
        Destroy(gameObject);
    }
}
