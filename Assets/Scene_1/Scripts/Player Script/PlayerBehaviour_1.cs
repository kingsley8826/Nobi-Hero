using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBehaviour_1 : MonoBehaviour {

    public static PlayerBehaviour_1 instance;
    public static bool isDead;
    public static bool isWin;
    public float health;
    public int money;
    public float moveForce = 20f;
    public float jumpForce = 600f;
    public float maxVelocity = 4f;
    public Text score;
    public Text bloodPercent;

    private bool canChangeGravity;
    private Vector2 vectorBack;

    private Rigidbody2D playerBody;

    private bool isThrow;

    public Animator animator;

    private float posX;

    private bool isGround;

    [SerializeField]
    public GameObject bullet;

    public bool canShoot = true;

    private Renderer myRenderer;

	private Color color;

    private bool canSlide = true;

    [SerializeField]
    private GameObject bulletExplosion;

    [SerializeField]
    private GameObject explosion;

    [SerializeField]

    private GameObject smoke;

    protected bool paused;


    void OnPauseGame()
    {
        paused = true;
    }


    void OnResumeGame()
    {
        paused = false;
    }

    void Awake()
    {
        //<      
        GameObject.Find("GamePlay Controller").GetComponent<PlayerBlood1>().blood = PlayerController.maxBlood;
        health = PlayerController.maxBlood;
        money = PlayerController.money;
        score.text = money + "";
        isDead = false;
        isWin = false;
        bloodPercent.text = health + " / " + PlayerController.maxBlood;
        //>
        myRenderer = GetComponent<Renderer>();
        color = myRenderer.material.color;
        if (instance == null)
        {
            instance = this;
        }
        animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
        canChangeGravity = true;
        posX = transform.position.x;
        isGround = true;
    }


    void FixedUpdate()
    {
        StartCoroutine(jump());
        slide();
        if (transform.position.x != posX)
        {
            vectorBack = new Vector2((posX - transform.position.x) * 0.15f, 0);
        }

    }

    /*void playerWalkKeyBoard() {
		if (Input.GetKey (KeyCode.UpArrow)) {
                playerBody.gravityScale = -playerBody.gravityScale;
		}

	}*/

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            if (canSlide == false)
            {
                Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
                S.y -= 0.65f;
                S.x -= 0.95f;
                gameObject.GetComponent<BoxCollider2D>().size = S;
            }
            else
            {
                Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
                S.y -= 0.35f;
                S.x -= 0.9f;
                gameObject.GetComponent<BoxCollider2D>().size = S;
            }


            Vector2 temp = playerBody.velocity;
            temp.x += vectorBack.x;
            playerBody.velocity = temp;


            if (Input.GetKey(KeyCode.Space))
            {
                if (canShoot)
                {
                    StartCoroutine(shoot());
                }
            }

        }
    }

    IEnumerator jump()
    {
		if (Input.GetKey(KeyCode.C) && canChangeGravity)
        {
            isGround = false;
            canChangeGravity = false;
            canSlide = true;
            animator.SetBool("Slide", false);
            playerBody.gravityScale = -playerBody.gravityScale;
			Vector3 temp = transform.localScale;
			temp.y = -temp.y;
			transform.localScale = temp;
            yield return new WaitForSeconds(0.3f);
            canChangeGravity = true;
        }

    }

    void slide()
    {
        if (transform.position.y < 0)
        {
            if (Input.GetKey(KeyCode.DownArrow) && canSlide && isGround)
            {
                animator.SetBool("Slide", true);
                canSlide = false;
                //yield return new WaitForSeconds(0f);
                // yield return new WaitForSeconds(0f);
            }
            if (!Input.GetKey(KeyCode.DownArrow) && isGround)
            {
                canSlide = true;
                animator.SetBool("Slide", false);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow) && canSlide && isGround)
            {
                animator.SetBool("Slide", true);
                canSlide = false;
                //yield return new WaitForSeconds(0f);
                // yield return new WaitForSeconds(0f);
            }
            if (!Input.GetKey(KeyCode.UpArrow) && isGround)
            {
                canSlide = true;
                animator.SetBool("Slide", false);
            }
        }

        /*

        if (Input.GetKey(KeyCode.DownArrow) && canSlide)
        {
            canSlide = false;
            animator.SetBool("Slide", true);
            yield return new WaitForSeconds(5f);
            canSlide = true;
            animator.SetBool("Slide", false);
            yield return new WaitForSeconds(5f);
        }*/


    }

    IEnumerator shoot()
    {
        canShoot = false;
        //SoundsManager.instance.playShootClip();
        yield return new WaitForSeconds(0.2f);
        Vector3 temp = transform.position;
        if (transform.position.y < 0)
        {
            temp.x += 1.3f;
            temp.y -= 0.2f;
        }
        else
        {
            temp.x += 1.3f;
            temp.y += 0.2f;
        }
        Instantiate(bullet, temp, Quaternion.identity);
		Sound.instance.playPlayerShootClip ();
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground")
            isGround = true;


    }

    void OnTriggerEnter2D(Collider2D target)
    {
		if (target.tag == "Enemy") {
			Sound.instance.playEnemyDeadClip ();
		}

        if (target.tag == "Enemy" || target.tag == "EnemyBullet" || target.tag == "Monster")
        {
            //<
            health -= 2f;
			StartCoroutine (flash ());
            GameObject.Find("GamePlay Controller").GetComponent<PlayerBlood1>().blood = health; 
            if (health <= 0)
            {
                isDead = true;
                Scene1Controller.instance.finishScene();
            }
            //>
            bloodPercent.text = health + " / " + PlayerController.maxBlood;

        }

        if (target.tag == "EnemyBullet")
        {
            Instantiate(bulletExplosion, target.transform.position, Quaternion.identity);
        }

        if (target.tag == "Enemy")
        {
            Vector3 temp = target.transform.position;
            temp.x -= 1f;
            temp.y -= 0.2f;
            Instantiate(smoke, temp, Quaternion.identity);
        }

        if (target.tag == "Monster")
        {
            Instantiate(explosion, target.transform.position, Quaternion.identity);
        }
        if (target.tag == "Coin")
        {
            Sound.instance.playPlayerEatCoinClip();
            PlayerController.money++;
            money = PlayerController.money;
            score.text = money + "";
        }

    }
		
	IEnumerator flash() {
		GetComponent<Renderer> ().material.color = new Color (1,0,0);
		yield return new WaitForSeconds(0.1f);
		GetComponent<Renderer> ().material.color = color;
		yield return new WaitForSeconds(0.1f);
		GetComponent<Renderer> ().material.color = new Color (1,0,0);
		yield return new WaitForSeconds(0.1f);
		GetComponent<Renderer> ().material.color = color;
	}
}
