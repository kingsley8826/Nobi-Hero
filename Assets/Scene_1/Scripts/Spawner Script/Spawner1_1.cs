using UnityEngine;
using System.Collections;

public class Spawner1_1 : MonoBehaviour {


    [SerializeField]
    private GameObject enemyType;

    public float interval;

    public Vector3 position;

    public bool canSpawn = true;

    /*public bool canSpawn = false;

    public bool getCanSpawn()
    {
        return canSpawn;
    }

    public void setCanSpawn(bool canSpawn)
    {
        this.canSpawn = canSpawn;
    }*/


    void FixedUpdate()
    {
        StartCoroutine(createEnemy());
    }


    IEnumerator createEnemy()
    {
        if (canSpawn)
        {
            Instantiate(enemyType, position, Quaternion.identity);
            canSpawn = false;
        }
        yield return new WaitForSeconds(0);
    }
}
