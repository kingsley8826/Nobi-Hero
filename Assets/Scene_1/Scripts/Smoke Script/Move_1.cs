using UnityEngine;
using System.Collections;

public class Move_1 : MonoBehaviour {

    public float speed;

    private Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        body.velocity = new Vector2(-speed, 0f);
    }
}
