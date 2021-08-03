using UnityEngine;
using System.Collections;

public class SharpBullet_3 : MonoBehaviour
{

    public static SharpBullet_3 instance;

    public float speed;
    public float speedX;
    public float speedY;

    public bool is45;
	public bool is30;
	public bool is60;

    private Rigidbody2D myBody;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        myBody = GetComponent<Rigidbody2D>();
        speedY = 0;
        is45 = false;
		is30 = false;
		is60 = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (is45) {
			speedX = (float)speed / (float)Mathf.Sqrt (2);
			speedY = Mathf.Abs (speedX * Mathf.Tan (35f));
		} else  {
            speedX = speed;
            speedY = 0;
        }
        Vector3 tempR = transform.rotation.eulerAngles;
        tempR.z = Mathf.Atan(speedY / speedX) * 45f;
        transform.rotation = Quaternion.Euler(tempR);
        myBody.velocity = new Vector2(speedX, speedY);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "honeyBullet" || target.tag == "honey" || target.tag == "bean")
        {
            Sound.instance.playEnemyDeadClip();
            Destroy(this.gameObject);
            //Destroy(target.gameObject);
            //GamePlayController.instance.planeDieShowPanel ();
        }
        if (target.tag == "border")
        {
            Destroy(this.gameObject);
        }
        if (target.tag == "ground")
        {
            Destroy(this.gameObject);
        }
    }
}
