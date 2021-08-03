using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

	public static EnemySpawner instance;

	[SerializeField]
	public GameObject enemyHoney;
	[SerializeField]
	public GameObject enemyBean;
	[SerializeField]
	public GameObject enemyBlue;
	[SerializeField]
	public GameObject boss;
    public GameObject coin;

    public bool finalBoss;

	public float minTime;
	public float maxTime;

	private int numberHoney;
	private int numberBean;
	private int numberBlue;

	private float rangeMin1 = 3.5f;
	private float rangeMax1 = 4.5f;
	private float rangeMin2 = 1.5f;
	private float rangeMax2 = 2.5f;

	public int First = 2;
	public int Second = 3;

    private Rigidbody2D sliderBody;
    private Rigidbody2D bossAvatarBody;
    private BoxCollider2D box;

    [SerializeField]
    public Canvas canvasFail;

    [SerializeField]
    public Canvas canvasSuccess;
    

    void Awake() {
		finalBoss = false;
		if (instance == null) {
			instance = this;
		}
		numberBean = 0;
		numberBlue = 0;
		numberHoney = 0;
        sliderBody = GameObject.Find("BossBlood Slider 3").GetComponent<Rigidbody2D>();
        bossAvatarBody = GameObject.Find("Boss Avatar 3").GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D> ();
	}	

	// Use this for initialization
	void Start () {
		StartCoroutine (spawnerEnemy ());
        StartCoroutine(SpawnerCoin());
    }

	// Update is called once per frame
	void Update () {

	}

	IEnumerator spawnerEnemy() {
		Vector3 temp = transform.position;
		var minY = -box.bounds.size.y / 2f;
		var maxY = box.bounds.size.y / 2f;
		temp.y += Random.Range (minY, maxY);
		if (numberBean < First) {
			numberBean++;
			Instantiate (enemyBean, temp, Quaternion.identity);
			yield return new WaitForSeconds (Random.Range (rangeMin1, rangeMax1));
		} else if (numberBean < Second) {
			numberBean++;
			Instantiate (enemyBean, temp, Quaternion.identity);
			yield return new WaitForSeconds (Random.Range (rangeMin2, rangeMax2));
		} else if (numberBlue < First) {
			numberBlue++;
			Instantiate (enemyBlue, temp, Quaternion.identity);
			yield return new WaitForSeconds (Random.Range (rangeMin1, rangeMax1));
		} else if (numberBlue < Second) {
			numberBlue++;
			Instantiate (enemyBlue, temp, Quaternion.identity);
			yield return new WaitForSeconds (Random.Range (rangeMin2, rangeMax2));
		} else if (numberHoney < First) {
			numberHoney++;
			Instantiate (enemyHoney, temp, Quaternion.identity);
			yield return new WaitForSeconds (Random.Range (rangeMin1, rangeMax1));
		} else if (numberHoney < Second) {
			numberHoney++;
			Instantiate (enemyHoney, temp, Quaternion.identity);
			yield return new WaitForSeconds (Random.Range (rangeMin2, rangeMax2));
		} else if (numberBean < First + Second * 3) {
			numberBean++;
			Instantiate (enemyBlue, temp, Quaternion.identity);
			temp.x += 1f;
			Instantiate (enemyHoney, temp, Quaternion.identity);
			temp.x -= 2f;
			Instantiate (enemyBean, temp, Quaternion.identity);
			yield return new WaitForSeconds (Random.Range (rangeMin1, rangeMax1));
		} else {
			finalBoss = true;
			yield return new WaitForSeconds (5f);
			temp.y = 2;
			temp.x += 2;
			Instantiate (boss, temp, Quaternion.identity);
            MoveSliderAndAvatar();
			yield return new WaitForSeconds (3f);
            StopSliderAndAvatar();
			GameObject BossFinal = (GameObject) GameObject.FindGameObjectWithTag ("boss");
            if (BossFinal != null)
            {
                BossFinal.GetComponent<Boss>().speed = 0;
                bossAction();
            }
		}
        if (!PlayerBehaviour.isDead)
        {
            if (finalBoss == false)
                StartCoroutine(spawnerEnemy());
        }        
	}
    void MoveSliderAndAvatar()
    {
        sliderBody.velocity = new Vector2(0f, -1);
        bossAvatarBody.velocity = new Vector2(0f, -1);
    }
    void StopSliderAndAvatar()
    {
        sliderBody.velocity = new Vector2(0f, 0f);
        bossAvatarBody.velocity = new Vector2(0f, 0f);
    }
    IEnumerator SpawnerCoin()
    {      
        Vector3 temp = transform.position;
        float maxY = box.bounds.size.y / 2f;
        temp.y = Random.Range(1f, maxY);
        int r = (Random.Range(1, 7));
        if (r == Type.coinX)
        {
            CoinManager.createX(coin, temp);
        }
        else if (r == Type.coinXXX)
        {
            CoinManager.createXXX(coin, temp);
        }
        else if (r == Type.coinRectangle)
        {
            CoinManager.createRectangle(coin, temp);
        }
        else if (r == Type.coinTriangle)
        {
            CoinManager.createTriangle(coin, temp);
        }
        else if (r == Type.coinCircle)
        {
            CoinManager.createCircle(coin, temp);
        }
        else if (r == Type.coinHeart)
        {
            CoinManager.createHeart(coin, temp);
        }
        yield return new WaitForSeconds(Random.Range(8f, 12f));
        if (!PlayerBehaviour.isDead && finalBoss == false)
        {
            StartCoroutine(SpawnerCoin());
        }        
    }

    void bossAction() {
		GameObject BossFinal = (GameObject) GameObject.FindGameObjectWithTag ("boss");
		Boss BossS = BossFinal.GetComponent<Boss> ();
		StartCoroutine (BossShoot1(BossS));
	}

	IEnumerator BossShoot1(Boss BossS) {
		BossS.playDoubleBullet ();
		yield return new WaitForSeconds (0.5f);
		if (BossS.blood > 100) {
			StartCoroutine (BossShoot1 (BossS));
		} else {
			throwChild ();
			StartCoroutine (BossShoot2 (BossS));
		}
	}
	IEnumerator BossShoot2(Boss BossS) {
		BossS.playDoubleBullet ();
		yield return new WaitForSeconds (0.5f);
		BossS.playTrippleBullet();
		yield return new WaitForSeconds (0.5f);
		if (BossS.blood > 50) {
			StartCoroutine (BossShoot2(BossS));
		} else {
			StartCoroutine (BossShoot3 (BossS));
			throwChild ();
			yield return new WaitForSeconds (0.5f);
			throwChild ();
		}
	}

	IEnumerator BossShoot3(Boss BossS) {
		BossS.playDoubleBullet ();
		yield return new WaitForSeconds (0.5f);
		BossS.playTrippleBullet();
		yield return new WaitForSeconds (0.5f);
		BossS.playFourBullet ();
		yield return new WaitForSeconds (0.5f);
		if (BossS.blood > 10) {
			StartCoroutine (BossShoot3 (BossS));
		} else {
			StartCoroutine (BossShoot4 (BossS));
			throwChild ();
			yield return new WaitForSeconds (0.5f);
			throwChild ();
			yield return new WaitForSeconds (0.5f);
			throwChild ();
		}
	}

	IEnumerator BossShoot4(Boss BossS) {
		BossS.playDoubleBullet ();
		yield return new WaitForSeconds (0.5f);
		BossS.playTrippleBullet();
		yield return new WaitForSeconds (0.5f);
		BossS.playFourBullet ();
		yield return new WaitForSeconds (0.5f);
		BossS.playFiveBullet ();
		yield return new WaitForSeconds (0.5f);
		if (BossS.blood > 0) {
			StartCoroutine (BossShoot4(BossS));
		}
        
	}

	void throwChild() {
		Vector3 temp = transform.position;
		//var minY = -box.bounds.size.y / 2f;
		//var maxY = box.bounds.size.y / 2f;
		//temp.y += Random.Range (minY, maxY);
		temp.y = Random.Range(3f,4f);
		Instantiate (enemyBlue, temp, Quaternion.identity);
		temp.y = Random.Range (2f, 3f);;
		Instantiate (enemyHoney, temp, Quaternion.identity);
		//temp.x -= 4f;
		temp.y = -2f;
		Instantiate (enemyBean, temp, Quaternion.identity);
	}
}
