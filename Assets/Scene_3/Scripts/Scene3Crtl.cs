using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene3Crtl : MonoBehaviour
{

    public float interval;
    private int randomNum;
    private ArrayList spawners = new ArrayList();
    private bool canSpawn;

    public static Scene3Crtl instance;

    [SerializeField]
    private Canvas CanvasGuide;


    [SerializeField]
    private Canvas CanvasPause;

    [SerializeField]
    private Text scoreFail;

    [SerializeField]
    private Text scoreSuccess;
    
    

    void Awake()
    {

        Time.timeScale = 0;
        UnityEngine.Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
        }
        _MakeInstance();


    }
    /*
    void Start()
    {
        StartCoroutine(spawn());
    }


    IEnumerator spawn()
    {
        if (canSpawn)
        {
            GameObject[] allGameObjects = (GameObject[])Resources.FindObjectsOfTypeAll(typeof(GameObject));
            foreach (GameObject go in allGameObjects)
            {
                try
                {
                    if (go.tag == "Spawner Enemies")
                        spawners.Add(go);
                }
                catch (Exception ex)
                {
                    Debug.Log(ex.Message);
                    continue;
                }
            }



            System.Random r = new System.Random();

            randomNum = r.Next(0, spawners.Count);


            ((GameObject)spawners[randomNum]).SetActive(true);
            yield return new WaitForSeconds(0.15f);

            foreach (UnityEngine.Object o in spawners)
            {
                ((GameObject)o).gameObject.SetActive(false);
            }

        ((GameObject)spawners[randomNum]).GetComponent<Spawner1_1>().canSpawn = true;

            yield return new WaitForSeconds(interval);

            StartCoroutine(spawn());
        }
    }
    */
    void Update()
    {
        if (this.scoreFail != null && this.scoreSuccess != null)
        {

        this.scoreFail.text = PlayerController.money + "";
        this.scoreSuccess.text = PlayerController.money + "";
        }
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        canSpawn = true;
    }



    public void finishScene()
    {
        canSpawn = false;
        PlayerBehaviour_1.instance.animator.SetBool("Finish", true);
        GameObject[] allGameObjects = (GameObject[])Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (GameObject go in allGameObjects)
        {
            try
            {
                if (go.tag == "Ground")
                {
                    go.GetComponent<AutoMove_1>().speedConstant = 0f;
                }
                if (go.tag == "Player")
                {
                    Destroy(go);
                }
                if (go.tag == "Avatar")
                {
                    PlayerBehaviour_1.isWin = true;
                    go.GetComponent<Move_1>().speed = 0f;
                }

            }

            catch (Exception ex)
            {
                Debug.Log(ex.Message);
                continue;
            }
        }

        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in allEnemy)
        {
            try
            {
                Destroy(go);
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
                continue;
            }
        }

        GameObject[] allMonster = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject go in allMonster)
        {
            try
            {
                Destroy(go);
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
                continue;
            }
        }

        GameObject[] allEnemyBullet = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject go in allEnemyBullet)
        {
            try
            {
                Destroy(go);
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
                continue;
            }
        }

        GameObject[] allCoin = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject go in allCoin)
        {
            try
            {
                Destroy(go);
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
                continue;
            }
        }

    }

    public void _GuideFinish()
    {
        Time.timeScale = 1;
        UnityEngine.Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
        }
        GameObject.FindGameObjectWithTag("PauseButton").gameObject.SetActive(true);
        CanvasGuide.gameObject.SetActive(false);
    }

    public void _PauseGame()
    {
        Time.timeScale = 0;
        UnityEngine.Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
        }
        CanvasPause.gameObject.SetActive(true);
    }

    public void _ResumeGame()
    {
        Time.timeScale = 1;
        UnityEngine.Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
        }
        CanvasPause.gameObject.SetActive(false);
    }

    public void _ReturnHome()
    {
        SceneManager.LoadScene("GameNavigator");
    }

    public Sprite OffMusic;
    public Sprite OnMusic;
    public Sprite OffSound;
    public Sprite OnSound;
    private GameObject but;

    public void _changeStateMusic()
    {
        Type.isSenceMute = !Type.isSenceMute;
        but = EventSystem.current.currentSelectedGameObject;
        if (but.GetComponent<Image>().sprite == OnMusic)
            but.GetComponent<Image>().sprite = OffMusic;
        else
        {
            but.GetComponent<Image>().sprite = OnMusic;
        }
    }

    public void _changeStateSound()
    {
        Type.isEffectMute = !Type.isEffectMute;

        but = EventSystem.current.currentSelectedGameObject;
        if (but.GetComponent<Image>().sprite == OnSound)
            but.GetComponent<Image>().sprite = OffSound;
        else
        {
            but.GetComponent<Image>().sprite = OnSound;
        }
    }

    public void _PlayAgain()
    {
        Application.LoadLevel(Application.loadedLevel);
    }


}
