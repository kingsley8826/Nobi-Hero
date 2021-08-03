using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

	public static PlayerBehaviour instance;
	public float moveForce = 20f;
	public float jumpForce = 600f;
	public float maxVelocity = 4f;

    public float blood;
    public int money;
    public Text score;
    public Text bloodPercent;
    public static bool isDead;
    private bool colBean = true;

    public Vector2 vectorBack;
	public Rigidbody2D playerBody;
	private Animator animator;
	private float posX = -6f;

    [SerializeField]
    private GameObject utilBullet;
    [SerializeField]
	public GameObject bullet1;
	[SerializeField]
	public GameObject bullet2;

	public int numOfBullet = 1;
	public int bulletDame = 1;

	private bool canShoot = true;
	private Color color;


	private bool way;

	private float minX, maxX, padding;

	private bool isRunning;
	private bool isGrounded;
	private bool is45;
	private bool isSlide;

    protected bool paused;


    void OnPauseGame()
    {
        paused = true;
    }


    void OnResumeGame()
    {
        paused = false;
    }


    void Awake() {
        score.text = PlayerController.money + "";
        GameObject.Find("GamePlay Controller").GetComponent<PlayerBlood_3>().blood = PlayerController.maxBlood;
        blood = PlayerController.maxBlood;
        money = PlayerController.money;
        isDead = false;
        bloodPercent.text = blood + " / " + PlayerController.maxBlood;
        way = true;
		color = GetComponent<Renderer> ().material.color;
		if (instance == null) {
			instance = this;
		}	
		animator = GetComponent<Animator> ();
		playerBody = GetComponent<Rigidbody2D> ();

		is45 = false;
		isRunning = false;
	}

	void Start () {
		padding = 0.7f;
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0f));
		minX = -bounds.x + padding;
		maxX = bounds.x - padding;
	}

	void FixedUpdate() {
		if (transform.position.x != posX) {
			vectorBack = new Vector2 ((posX - transform.position.x)*0.15f,0);
		}
	}


    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            if (!EnemySpawner.instance.finalBoss && isGrounded)
            {
                Vector2 temp = playerBody.velocity;
                temp.x += vectorBack.x;
                playerBody.velocity = temp;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (canShoot)
                {
                    StartCoroutine(shoot());
                }
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (isGrounded && playerBody.velocity.y == 0)
                {
                    StartCoroutine(jump());
                }
            }
            if (Input.GetKey(KeyCode.C))
            {
                if (GameObject.Find("GamePlay Controller").GetComponent<PlayerUtil_3>().utilValue >= 10)
                {
                    creatUtilBullet();
                    GameObject.Find("GamePlay Controller").GetComponent<PlayerUtil_3>().utilValue = 0;
                }
            }
            if (EnemySpawner.instance.finalBoss && GameObject.FindGameObjectWithTag("boss") != null)
            {
                playerWalkKeyBoard();
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                isSlide = true;
            }
            else
            {
                isSlide = false;
            }

            if (Input.GetKey(KeyCode.X))
            {
                is45 = true;
            }
            else
            {
                is45 = false;
            }
            // boundary for player
            Vector3 tempP = transform.position;
            if (tempP.x < minX)
            {
                tempP.x = minX;
            }
            else if (tempP.x > maxX)
            {
                tempP.x = maxX;
            }

			if (GameObject.FindGameObjectWithTag ("BGQuad").GetComponent<BGScripts> ().scrollSpeed != 0 && isGrounded)
            {
                isRunning = true;
            }
            transform.position = tempP;
            animator.SetBool("isJumping", !isGrounded);
            animator.SetBool("is45", is45);
            animator.SetBool("isRunning", isRunning);
            animator.SetBool("isSliding", isSlide);
        }
    }

    void creatUtilBullet()
    {
        Vector3 location = transform.position;
        location.x += 1f;
        location.y -= 0.4f;
        Instantiate(utilBullet, location, Quaternion.identity);
    }

    void playerWalkKeyBoard() {
		float forceX = 0f;
		float forceY = 0f;

		float vel = Mathf.Abs (playerBody.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal");

		if (h > 0) {
			way = true;
			if (vel < maxVelocity) {
					forceX = moveForce;
			}
			Vector3 scale = transform.localScale;
			scale.x = 0.6f;
			transform.localScale = scale;
			isRunning = true;
		} else if (h < 0) {
			way = false;
			if (vel < maxVelocity) {
				forceX = -moveForce;
			}
			Vector3 scale = transform.localScale;
			scale.x = -0.6f;
			transform.localScale = scale;
			isRunning = true;
		} else {
			isRunning = false;
		}
		playerBody.AddForce (new Vector2 (forceX, forceY));
	}
		
	void playJump() {
		isGrounded = false;
		float forceY = jumpForce;
		playerBody.AddForce (new Vector2 (0, forceY));
		animator.SetBool ("isJumping", true);
	}

	IEnumerator jump() {
		isGrounded = false;
		float forceY = jumpForce;
		playerBody.AddForce (new Vector2 (0, forceY));
		yield return new WaitForSeconds (1f);
	}

	IEnumerator shoot() {
		canShoot = false;
		yield return new WaitForSeconds (0.05f);
		Sound.instance.playPlayerShootClip();

		Vector3 temp = transform.position;
		if (!way) {
			temp.x -= 1f;
			temp.y -= 0.2f;
		} else {
			temp.x += 1f;
			temp.y -= 0.2f;
		}

		GameObject BulletX1;
		GameObject BulletX2;
		GameObject BulletX3;
		float x = -1.5f;
		if (bulletDame == 2) x = -0.35f;

		if (numOfBullet == 1) {
			
			if (bulletDame == 1) {
				BulletX1 = (GameObject)Instantiate (bullet1);
			} else {
				BulletX1 = (GameObject)Instantiate (bullet2);
			}
			SharpBullet_3 inst = BulletX1.GetComponent<SharpBullet_3> ();
			if (is45) {
				inst.is45 = true;
				temp.y += 0.6f;
			}
			if (!way) {
				inst.speed = -inst.speed;
				Vector2 scale = BulletX1.transform.localScale;
				scale.x = x;
				BulletX1.transform.localScale = scale;
			}
			BulletX1.transform.position = temp;
		} else if (numOfBullet == 2) {

			if (bulletDame == 1) {
				BulletX1 = (GameObject)Instantiate (bullet1);
			} else {
				BulletX1 = (GameObject)Instantiate (bullet2);
			}

			if (bulletDame == 1) {
				BulletX2 = (GameObject)Instantiate (bullet1);
			} else {
				BulletX2 = (GameObject)Instantiate (bullet2);
			}
				
			SharpBullet_3 inst1 = BulletX1.GetComponent<SharpBullet_3> ();
			SharpBullet_3 inst2 = BulletX2.GetComponent<SharpBullet_3> ();

			if (is45) {
				inst1.is45 = true;
				temp.y += 0.6f;
			} else {
				temp.y += 0.2f;
			}

			if (!way) {
				inst1.speed = -inst1.speed;
				Vector2 scale = BulletX1.transform.localScale;
				scale.x = x;
				BulletX1.transform.localScale = scale;
			}
			BulletX1.transform.position = temp;
			if (is45) {
				inst2.is45 = true;
				temp.y -= 0.3f;
			} else {
				temp.y -= 0.4f;
			}
			if (!way) {
				inst2.speed = -inst2.speed;
				Vector2 scale = BulletX2.transform.localScale;
				scale.x = x;
				BulletX2.transform.localScale = scale;
			}
			BulletX2.transform.position = temp;
		} else if (numOfBullet == 3) {
			if (bulletDame == 1) {
				BulletX1 = (GameObject)Instantiate (bullet1);
			} else {
				BulletX1 = (GameObject)Instantiate (bullet2);
			}

			if (bulletDame == 1) {
				BulletX2 = (GameObject)Instantiate (bullet1);
			} else {
				BulletX2 = (GameObject)Instantiate (bullet2);
			}
			if (bulletDame == 1) {
				BulletX3 = (GameObject)Instantiate (bullet1);
			} else {
				BulletX3 = (GameObject)Instantiate (bullet2);
			}

			SharpBullet_3 inst1 = BulletX1.GetComponent<SharpBullet_3> ();
			SharpBullet_3 inst2 = BulletX2.GetComponent<SharpBullet_3> ();
			SharpBullet_3 inst3 = BulletX3.GetComponent<SharpBullet_3> ();

			if (is45) {
				inst1.is45 = true;
				temp.y += 0.9f;
			} else {
				temp.y += 0.6f;
			}

			if (!way) {
				inst1.speed = -inst1.speed;
				Vector2 scale = BulletX1.transform.localScale;
				scale.x = x;
				BulletX1.transform.localScale = scale;
			}
			BulletX1.transform.position = temp;
			if (is45) {
				inst2.is45 = true;
				temp.y -= 0.3f;
			} else {
				temp.y -= 0.3f;
			}
			if (!way) {
				inst2.speed = -inst2.speed;
				Vector2 scale = BulletX2.transform.localScale;
				scale.x = x;
				BulletX2.transform.localScale = scale;
			}
			BulletX2.transform.position = temp;

			if (is45) {
				inst3.is45 = true;
				temp.y -= 0.3f;
			} else {
				temp.y -= 0.3f;
			}
			if (!way) {
				inst3.speed = -inst3.speed;
				Vector2 scale = BulletX3.transform.localScale;
				
				scale.x = x;
				BulletX3.transform.localScale = scale;
			}
			BulletX3.transform.position = temp;
		}

		yield return new WaitForSeconds (0.2f);
		canShoot = true;
	}

	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "ground") {
			isGrounded = true;
		}
	}
	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "honeyBullet" || target.tag == "honey") {
			StartCoroutine (flash());
            blood -= 1f;
            GameObject.Find("GamePlay Controller").GetComponent<PlayerBlood_3>().blood = blood;
        }
        if (target.tag == "bean")
        {
            if (colBean)
            {
                StartCoroutine(collisionBean(target));
            }
        }
		if (target.tag == "inBulletDame") {
			bulletDame++;
		}
		if (target.tag == "inNumBullet") {
			if (numOfBullet < 3)
			numOfBullet++;
		}

		if (target.tag == "inPBlood") {
			blood += 3;
			if (blood > PlayerController.maxBlood) {
				blood = PlayerController.maxBlood;
			}
			GameObject.Find ("GamePlay Controller").GetComponent<PlayerBlood_3> ().blood = blood;
		}

        if(target.tag == "border")
        {
            blood = 0f;
            GameObject.Find("GamePlay Controller").GetComponent<PlayerBlood_3>().blood = blood;
        }
        bloodPercent.text = blood + " / " + PlayerController.maxBlood;
        if (target.tag == "Coin")
        {
            Sound.instance.playPlayerEatCoinClip();
            PlayerController.money++;
            money = PlayerController.money;
            score.text = money + "";
        }

        if (GameObject.Find("GamePlay Controller").GetComponent<PlayerBlood_3>().blood <= 0)
        {
            isDead = true;
            EnemySpawner.instance.canvasFail.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }

    IEnumerator collisionBean(Collider2D target)
    {
        colBean = false;       
        blood -= 2f;
        GameObject.Find("GamePlay Controller").GetComponent<PlayerBlood_3>().blood = blood;
        yield return new WaitForSeconds(1f);
        colBean = true;
    }


    void shake() {
		Vector2 temp = playerBody.velocity;
		temp.x += -1;
		playerBody.velocity = temp;
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
