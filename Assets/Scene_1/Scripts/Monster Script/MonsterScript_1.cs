using UnityEngine;
using System.Collections;

public class MonsterScript_1 : MonoBehaviour {

    public float speed;

    private Rigidbody2D body;

    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private GameObject bullet;

    private Animator anim;

    private BoxCollider2D box;

    

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        box.isTrigger = true;
        GetComponent<SpriteRenderer>().sortingOrder = 1;
        this.tag = "Monster";
    }


    void FixedUpdate()
    {
        body.velocity = new Vector2(-speed, 0f);
    }

    IEnumerator shoot()
    {

        Vector3 temp = transform.position;
        temp.x -= 0.5f;
        temp.y -= 0.5f;
        Instantiate(bullet, temp, Quaternion.identity);
		Sound.instance.playEnemyShootClip ();
        yield return new WaitForSeconds(Random.Range(1.5f, 2.5f));
        StartCoroutine(shoot());
    }

    void Start()
    {
        StartCoroutine(shoot());
    }

    
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "bullet" ||target.tag == "Player")
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
