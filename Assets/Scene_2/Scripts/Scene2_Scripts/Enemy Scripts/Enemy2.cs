using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour
{
	[SerializeField]
	public GameObject explosionAnimationBullet;
	[SerializeField]
	public GameObject explosionAnimationDead;
	
    public int speed;
    public float blood;
    protected Rigidbody2D myBody;

    [SerializeField]
    protected GameObject bullet;
    [SerializeField]
    protected GameObject BulletDameItem;
    [SerializeField]
    protected GameObject NumBulletItem;
    [SerializeField]
    protected GameObject inBloodItem;

    protected int itemType;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        itemType = Random.Range(1, 16);

    }
    void Start()
    {
        StartCoroutine(EnemyShoot());
    }
    IEnumerator EnemyShoot()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        Vector3 temp = transform.position;
        temp.x -= 0.8f;
        Instantiate(bullet, temp, Quaternion.identity);
        StartCoroutine(EnemyShoot());
    }
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(-speed, 0f);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "KillerLeft" )
        {
            Destroy(gameObject);
        }
		if (target.tag == "UtilBullet") {
			blood = 0;
		}

        if (target.tag == "PlayerBullet1" || target.tag == "Player" )
        {
            blood -= 1f;
			if (blood > 0)
			playExplosionBullet ();
        }
        if (target.tag == "PlayerBullet2")
        {
            blood -= 1.5f;
			if (blood > 0)
			playExplosionBullet ();
        }
        if (target.tag == "PlayerBullet3")
        {
            blood -= 2.5f;
			if (blood > 0)
			playExplosionBullet ();
        }

		if (blood <= 0)
		{
			Vector3 temp2 = transform.position;
			if (itemType == Type.inscreaseBullet)
			{
				Instantiate(NumBulletItem, temp2, Quaternion.identity);
			}
			else if (itemType == Type.upgradeBullet)
			{
				Instantiate(BulletDameItem, temp2, Quaternion.identity);
			}
			else if (itemType == Type.inscreaseBlood)
			{
				Instantiate(inBloodItem, temp2, Quaternion.identity);
			}
			Destroy(gameObject);
			playExplosioDead ();
		}
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
