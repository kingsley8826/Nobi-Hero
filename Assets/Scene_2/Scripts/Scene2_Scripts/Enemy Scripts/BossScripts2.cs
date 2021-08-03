using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class BossScripts2 : MonoBehaviour {

	[SerializeField]
	public GameObject explosionAnimationBullet;
	[SerializeField]
	public GameObject explosionAnimationDead;

    public float speedX;
    public float speedY;
    public float blood;
    private float minY;
    private float maxY;
    private bool moveUp = true;
    private Rigidbody2D myBody;
    private Rigidbody2D sliderBody;
    private Rigidbody2D bossAvatarBody;
    private float maxDistance = 5f;
    [SerializeField]
    private GameObject bullet;


    public static bool active = false;


    [SerializeField]
    private Canvas canvasSuccess;
    
    // Use this for initialization

    void Awake(){
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        minY = -bounds.y + 1f;
        maxY = bounds.y - 1.4f;
        myBody = GetComponent<Rigidbody2D>();
        sliderBody = GameObject.Find("BossBlood Slider").GetComponent<Rigidbody2D>();
        bossAvatarBody = GameObject.Find("Boss Avatar").GetComponent<Rigidbody2D>();
        GameObject.Find("GamePlay Controller").GetComponent<BossBlood2>().blood = blood;
    }

    void Start(){
        StartCoroutine(EnemyShoot());
    }
    // Update is called once per frame
    void FixedUpdate(){
        Vector3 temp = transform.position;
        if (maxDistance >= 0){
            myBody.velocity = new Vector2(-speedX, 0f);
            MoveSliderAndAvatar();    
            maxDistance -= speedX * Time.deltaTime;
        } else{
            if(temp.y < minY)
            {
                moveUp = true;
            }
            if(temp.y > maxY)
            {
                moveUp = false;
            }
            if (moveUp)
            {
                myBody.velocity = new Vector2(0f, speedY);
            }else
            {
                myBody.velocity = new Vector2(0f, -speedY);
            }
            StopSliderAndAvatar();
        }

    }
    IEnumerator EnemyShoot(){
        yield return new WaitForSeconds(Random.Range(0.4f, 0.8f));

        Vector3 temp = transform.position;
        temp.x -= 2f;
        temp.y -= 1.5f;
        Instantiate(bullet, temp, Quaternion.identity);
        temp.y += 1.5f;
        Instantiate(bullet, temp, Quaternion.identity);
        temp.y += 1.5f;
        Instantiate(bullet, temp, Quaternion.identity);
        StartCoroutine(EnemyShoot());
    }
    void OnTriggerEnter2D(Collider2D target){
        if (maxDistance <= 0)
        {
            if (target.tag == "PlayerBullet1" || target.tag == "Player")
            {
                blood -= 1f;
				if (blood > 0)
				playExplosionBullet ();
            }
            else if (target.tag == "PlayerBullet2")
            {
                blood -= 1.5f;
				if (blood > 0)
					playExplosionBullet ();
            }
            else if (target.tag == "PlayerBullet3")
            {
                blood -= 2.5f;
				if (blood > 0)
					playExplosionBullet ();
            }
            else if(target.tag == "UtilBullet")
            {
                blood -= 20f;
				if (blood > 0)
					playExplosionBullet ();
            }
        }
        GameObject.Find("GamePlay Controller").GetComponent<BossBlood2>().blood = blood;
        if (GameObject.Find("GamePlay Controller").GetComponent<BossBlood2>().blood <= 0){
            Spawner2.instance.canvasSucess.gameObject.SetActive(true);
            PlayerController.setOpenDoor2();
			int star2;
			if (GameObject.Find ("GamePlay Controller").GetComponent<PlayerBlood2> ().blood >= PlayerController.maxBlood * 0.8) {
				star2 = 3;
			} else if (GameObject.Find ("GamePlay Controller").GetComponent<PlayerBlood2> ().blood >= PlayerController.maxBlood * 0.5) {
				star2 = 2;
			} else if (GameObject.Find ("GamePlay Controller").GetComponent<PlayerBlood2> ().blood >= PlayerController.maxBlood * 0.2) {
				star2 = 1;
			} else {
				star2 = 0;
			}
			PlayerController.setStar_lv2 (star2);

            if (star2 == 0)
            {
                GameObject.FindGameObjectWithTag("CurrentStar").GetComponent<Animator>().SetTrigger("Rate 0");
            }
            else if (star2 == 1)
            {
                GameObject.FindGameObjectWithTag("CurrentStar").GetComponent<Animator>().SetTrigger("Rate 1");
            }
            else if (star2 == 2)
            {
                GameObject.FindGameObjectWithTag("CurrentStar").GetComponent<Animator>().SetTrigger("Rate 2");
            }
            else if (star2 == 3)
            {
                GameObject.FindGameObjectWithTag("CurrentStar").GetComponent<Animator>().SetTrigger("Rate 3");
            }
            Destroy(gameObject);
			playExplosioDead ();
        }
    }

    void MoveSliderAndAvatar(){
        sliderBody.velocity = new Vector2(0f, -speedX);
        bossAvatarBody.velocity = new Vector2(0f, -speedX);
        maxDistance -= speedX * Time.deltaTime;
    }
    void StopSliderAndAvatar(){
        sliderBody.velocity = new Vector2(0f, 0f);
        bossAvatarBody.velocity = new Vector2(0f, 0f);
    }
	void playExplosionBullet() {
		GameObject explosion = (GameObject)Instantiate (explosionAnimationBullet);
		explosion.transform.position = transform.position;
	}
	void playExplosioDead() {
		GameObject explosion = (GameObject)Instantiate (explosionAnimationDead);
		explosion.transform.position = transform.position;
	}
}
