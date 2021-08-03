using UnityEngine;
using System.Collections;

public class SharpBullet_1 : MonoBehaviour {

    public float speed;

    private Rigidbody2D myBody;

    [SerializeField]
    private GameObject bulletExplosion;

    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private GameObject smoke;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, 0);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        
        if (target.tag == "ground")
        {
            Destroy(this.gameObject);
        }

        if (target.tag == "EnemyBullet")
        {
            Instantiate(bulletExplosion, target.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (target.tag == "Enemy")
        {
            Vector3 temp = target.transform.position;
            temp.x -= 1f;
            temp.y -= 0.2f;
            Instantiate(smoke, temp, Quaternion.identity);
            Destroy(gameObject);
        }

        if (target.tag == "Monster")
        {
            Vector3 temp = transform.position;
            temp.x -= 0.1f;
            Instantiate(explosion, temp, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
