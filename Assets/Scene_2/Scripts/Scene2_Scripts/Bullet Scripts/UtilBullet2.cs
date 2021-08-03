using UnityEngine;
using System.Collections;

public class UtilBullet2 : Bullet2 {

    public float dame;

    void Update()
    {
        if(dame <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "KillerLeft" || target.tag == "KillerRight" || target.tag == "Boss")
        {
            Destroy(gameObject);
        }
        if (target.tag == "Enemy")
        {
            dame -= 1f;
        }
    }
}
