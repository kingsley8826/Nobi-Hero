using UnityEngine;
using System.Collections;

public class Item2 : MonoBehaviour {

    public float speedX;
    private Rigidbody2D myBody;
    // Use this for initialization

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speedX, 0);
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player" || target.tag == "Killer")
        {
            Destroy(gameObject);
        }
    }
}
