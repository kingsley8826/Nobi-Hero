using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class Scene2Crtl : MonoBehaviour {
    public static Scene2Crtl instance;

    [SerializeField]
    private Canvas CanvasGuide;


    [SerializeField]
    private Canvas CanvasPause;

    [SerializeField]
    private Text scoreFail;

    [SerializeField]
    private Text scoreSuccess;

    [SerializeField]
    private Button pauseButton;

    void Awake()
    {
        Time.timeScale = 0;
        UnityEngine.Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
        }
        _MakeInstance();
        pauseButton.gameObject.SetActive(false);

    }

    void Update()
    {
        this.scoreFail.text = PlayerController.money + "";
        this.scoreSuccess.text = PlayerController.money + "";
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
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
        pauseButton.gameObject.SetActive(true);
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
        SceneManager.LoadScene("Scene2");
    }
}
