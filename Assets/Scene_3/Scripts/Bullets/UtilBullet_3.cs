using UnityEngine;
using System.Collections;

public class UtilBullet_3 : Bullet2 {

    public float dame;

    void Update()
    {
        if (dame <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "border" || target.tag == "boss")
        {
            Destroy(gameObject);
        }
        if (target.tag == "honey")
        {
            dame -= 1f;
            Destroy(target.gameObject);
        }
        if (target.tag == "bean")
        {
            dame -= 1f;
            cameraShake.instance.Shake();
            Destroy(target.gameObject);
        }
        
    }
}
