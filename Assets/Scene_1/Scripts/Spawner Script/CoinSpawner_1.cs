using UnityEngine;
using System.Collections;

public class CoinSpawner_1 : MonoBehaviour {

    public GameObject coin;

    private BoxCollider2D box;

    // Use this for initialization
    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        StartCoroutine(SpawnerCoin());
    }

    IEnumerator SpawnerCoin()
    {
        yield return new WaitForSeconds(Random.Range(2f, 3f));
        Vector3 temp = transform.position;
        float maxY = box.bounds.size.y / 2f;
        temp.y = Random.Range(-1f, maxY);
        int r = (Random.Range(1, 6));
        if (r == Type.coinHorizontal)
        {
            CoinManager.createHorizontal(coin, temp);
        }
        else if (r == Type.coinCrossLine1)
        {
            CoinManager.createCrossLine1(coin, temp);
        }
        else if (r == Type.coinCrossLine2)
        {
            CoinManager.createCrossLine2(coin, temp);
        }
        else if (r == Type.coinSquare)
        {
            CoinManager.createSquare(coin, temp);
        }
        else if (r == Type.coinMiniCircle)
        {
            CoinManager.createMiniCircle(coin, temp);
        }
        if (!PlayerBehaviour_1.isDead && !PlayerBehaviour_1.isWin)
        {
            StartCoroutine(SpawnerCoin());
        }
    }
}
