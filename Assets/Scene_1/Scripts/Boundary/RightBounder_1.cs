using UnityEngine;
using System.Collections;

public class RightBounder_1 : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target)
    {
        Destroy(target.gameObject);
    }
}
