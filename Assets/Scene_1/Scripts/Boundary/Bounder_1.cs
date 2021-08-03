using UnityEngine;
using System.Collections;

public class Bounder_1 : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "bullet")
            Destroy(target.gameObject);
    }
}
