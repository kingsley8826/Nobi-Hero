using UnityEngine;
using System.Collections;

public class MonsterScript_Land_1 : MonoBehaviour {

    public float speed;

    private Rigidbody2D body;
    
    [SerializeField]
    private GameObject explosion;

    private Animator anim;


    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GetComponent<SpriteRenderer>().sortingOrder = 1;
        anim.SetBool("GotHit", false);
        this.tag = "Monster";
    }


    void FixedUpdate()
    {
        body.velocity = new Vector2(-speed, 0f);
    }

    
   

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "bullet" || target.tag == "Player")
        {
            
                Vector3 tempY = transform.position;
                tempY.y += 0.1f;
                transform.position = tempY;
                anim.SetBool("GotHit", true);
        }

        if (target.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }
}
