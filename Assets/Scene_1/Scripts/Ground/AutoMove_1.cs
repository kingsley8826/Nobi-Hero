using UnityEngine;
using System.Collections;

public class AutoMove_1 : MonoBehaviour {

    public float speedConstant;

    public Vector3 lastGround = new Vector3(23.36f, -5.7f, 0f);

    // Use this for initialization
    void Awake()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x <= -4.67)
        {
            transform.position = lastGround;
        }
        Vector2 vel = transform.position;
        vel.x -= speedConstant;
        transform.position = vel;
    }
}
