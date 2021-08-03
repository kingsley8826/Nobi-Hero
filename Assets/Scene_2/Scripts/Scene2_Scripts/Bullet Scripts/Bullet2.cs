﻿using UnityEngine;
using System.Collections;

public class Bullet2 : MonoBehaviour {

    public float speedX;
    public float speedY;
    private Rigidbody2D myBody;
    // Use this for initialization

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speedX, speedY);
    }
}
