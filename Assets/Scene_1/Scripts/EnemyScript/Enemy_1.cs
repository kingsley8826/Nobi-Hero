using UnityEngine;
using System.Collections;

public class Enemy_1 : MonoBehaviour {


    public float speed;

    private Rigidbody2D body;


    private BoxCollider2D box;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        box.isTrigger = true;
        this.tag = "Enemy";
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }


    void FixedUpdate()
    {
        body.velocity = new Vector2(-speed, 0f);
    }



    
}
