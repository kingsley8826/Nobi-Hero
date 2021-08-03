using UnityEngine;
using System.Collections;

public class Spawner2 : MonoBehaviour {

    [SerializeField]
    private GameObject ghostEnemy;
    [SerializeField]
    private GameObject blueEnemy;
    [SerializeField]
    private GameObject blackEnemy;

    [SerializeField]
    private GameObject boss;

    public GameObject coin;

    private BoxCollider2D box;
    public int maxEnemy;
    public int numOfGhost;
    public int numOfBlue;
    public int numOfBlack;
    private int numOfEnemy;

    [SerializeField]
    public Canvas canvasSucess;

    public static Spawner2 instance;

	// Use this for initialization
	void Awake () {
        box = GetComponent<BoxCollider2D>();
        numOfEnemy = maxEnemy;
        if (instance == null) instance = this;
	}

    void Start()
    {
        StartCoroutine(SpawnerEnemy());
        StartCoroutine(SpawnerCoin());
    }
	
   

    IEnumerator SpawnerEnemy()
    {
        yield return new WaitForSeconds(Random.Range(2f, 3f));
        float minY = -box.bounds.size.y / 2f;
        float maxY = box.bounds.size.y / 2f;
        Vector3 temp = transform.position;

        temp.y = Random.Range(minY, maxY);
        if (numOfEnemy > (maxEnemy - numOfGhost)){            
            Instantiate(ghostEnemy, temp, Quaternion.identity);
            numOfEnemy--;
            if (!Nobita2.isDead)
            {
                StartCoroutine(SpawnerEnemy());
            }         
        }else if(numOfEnemy > (maxEnemy - numOfGhost - numOfBlue)){
            Instantiate(blueEnemy, temp, Quaternion.identity);
            numOfEnemy--;
            if (!Nobita2.isDead)
            {
                StartCoroutine(SpawnerEnemy());
            }
        }else if (numOfEnemy > (maxEnemy - numOfGhost - numOfBlue - numOfBlack)){
            Instantiate(blackEnemy, temp, Quaternion.identity);
            numOfEnemy--;
            if (!Nobita2.isDead)
            {
                StartCoroutine(SpawnerEnemy());
            }
        }else{
            temp = transform.position;
            Instantiate(boss, temp, Quaternion.identity);
        }      
    }
    IEnumerator SpawnerCoin()
    {
        
        Vector3 temp = transform.position;
        float maxY = box.bounds.size.y / 2f;
        temp.y = Random.Range(-1f, maxY);
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
        if (!Nobita2.isDead && numOfEnemy > 0) {           
            yield return new WaitForSeconds(Random.Range(12f, 15f));
            StartCoroutine(SpawnerCoin());
        }
    }
        
}
