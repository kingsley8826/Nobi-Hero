using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Sprite OffMusic;
    public Sprite OnMusic;
    public Sprite OffSound;
    public Sprite OnSound;
    private GameObject but;

    void Awake()
    {
        if (Type.isEffectMute == true)
        {
            GameObject.FindGameObjectWithTag("SoundButton").GetComponent<Image>().sprite = OnSound;
        }
        else
        {
            GameObject.FindGameObjectWithTag("SoundButton").GetComponent<Image>().sprite = OffSound;

        }

        if (Type.isSenceMute == true)
        {
            GameObject.FindGameObjectWithTag("MusicButton").GetComponent<Image>().sprite = OnMusic;
        }
        else
        {
            GameObject.FindGameObjectWithTag("MusicButton").GetComponent<Image>().sprite = OffMusic;

        }
    }

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


    public void _playGame()
    {
        SceneManager.LoadScene("GameNavigator");
    }
    public void _exitGame()
    {
        Application.Quit();
    }

}