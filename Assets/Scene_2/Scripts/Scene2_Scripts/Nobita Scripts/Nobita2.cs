using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Nobita2 : MonoBehaviour {

    public static bool isDead;

    public float speed;
    public float blood;
    public int money;
    public Text score;
    public Text bloodPercent;

    private Rigidbody2D myBody;

    [SerializeField]
    private GameObject utilBullet;

    [SerializeField]
    private GameObject bullet1;
    [SerializeField]
    private GameObject bullet1UR;
    [SerializeField]
    private GameObject bullet1DR;

    [SerializeField]
    private GameObject bullet2;
    [SerializeField]
    private GameObject bullet2UR;
    [SerializeField]
    private GameObject bullet2DR;

    [SerializeField]
    private GameObject bullet3;
    [SerializeField]
    private GameObject bullet3UR;
    [SerializeField]
    private GameObject bullet3DR;

    [SerializeField]
    private Canvas CanvasFailed;

    public int bulletDame = 1;
    public int numOfBullet = 1;
    private bool canShoot = true;

	private Color color;

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
		color = GetComponent<Renderer> ().material.color;
	}
    // Use this for initialization
    void Start () {        
        myBody = GetComponent<Rigidbody2D>();
        GameObject.Find("GamePlay Controller").GetComponent<PlayerBlood2>().blood = PlayerController.maxBlood;
        blood = PlayerController.maxBlood;
        money = PlayerController.money;
        isDead = false;
        bloodPercent.text = blood + " / " + PlayerController.maxBlood;
        score.text = PlayerController.money + "";
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        move();
	}

    void Update() {
        if (!paused)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (canShoot)
                {
                    StartCoroutine(Shoot());
                }
            }

            if (Input.GetKey(KeyCode.C))
            {
                if (GameObject.Find("GamePlay Controller").GetComponent<PlayerUtil2>().utilValue >= 10)
                {
                    creatUtilBullet();
                    GameObject.Find("GamePlay Controller").GetComponent<PlayerUtil2>().utilValue = 0;
                }
            }

        }

        
    }

    void move(){
        float xAxis = Input.GetAxisRaw("Horizontal") * speed;
        float yAxis = Input.GetAxisRaw("Vertical") * speed;
        myBody.velocity = new Vector2(xAxis, yAxis);
    }
    void creatUtilBullet()
    {
        Vector3 location = transform.position;
        location.x += 1f;
        location.y -= 0.4f;
        Instantiate(utilBullet, location, Quaternion.identity);
    }
    IEnumerator Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.2f);
        Vector3 location = transform.position;
        createBullet(location);
		Sound.instance.playPlayerShootClip ();
        canShoot = true;
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "GrayBullet" || target.tag == "Enemy" || target.tag == "Boss" || target.tag == "BossBullet")
        {
            blood -= 1f;
            GameObject.Find("GamePlay Controller").GetComponent<PlayerBlood2>().blood = blood;
            bloodPercent.text = blood + " / " + PlayerController.maxBlood;
			StartCoroutine (flash ());
        }      
        if (GameObject.Find("GamePlay Controller").GetComponent<PlayerBlood2>().blood <= 0)
        {
            isDead = true;
            CanvasFailed.gameObject.SetActive(true);
            Destroy(gameObject);
        }
        if(target.tag == "inBulletDame")
        {
            if (bulletDame < 3)
            {
                bulletDame++;
            }
        }
        if (target.tag == "inNumBullet")
        {
            if(numOfBullet < 3)
            {
                numOfBullet++;
            }
        }
        if (target.tag == "inPBlood")
        {
            blood += 3;
            if (blood > PlayerController.maxBlood)
            {
                blood = PlayerController.maxBlood; ;
            }
            GameObject.Find("GamePlay Controller").GetComponent<PlayerBlood2>().blood = blood;
            bloodPercent.text = blood + " / " + PlayerController.maxBlood;
        }
        if (target.tag == "Coin")
        {
            Sound.instance.playPlayerEatCoinClip();
            PlayerController.money++;
            money = PlayerController.money;
            score.text = money + "";
        }     
    }
    private void createBullet(Vector3 location)
    {
        location.x += 1f;
        location.y -= 0.4f;
        if (bulletDame == 1)
        {
            createBullet(bullet1, bullet1UR, bullet1DR, location);
        }
        else if (bulletDame == 2)
        {
            createBullet(bullet2, bullet2UR, bullet2DR, location);
        }
        else if (bulletDame == 3)
        {
            createBullet(bullet3, bullet3UR, bullet3DR, location);
        }
    }
    private void createBullet(GameObject bullet, GameObject bulletUR, GameObject bulletDR, Vector3 location)
    {
        if (numOfBullet == 1)
        {
            Instantiate(bullet, location, Quaternion.identity);
        }
        else if (numOfBullet == 2)
        {
            location.y -= 0.2f;
            Instantiate(bullet, location, Quaternion.identity);
            location.y += 0.4f;
            Instantiate(bullet, location, Quaternion.identity);
        }
        else if (numOfBullet == 3)
        {
            Instantiate(bullet, location, Quaternion.identity);
            Instantiate(bulletUR, location, Quaternion.identity);
            Instantiate(bulletDR, location, Quaternion.identity);
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
