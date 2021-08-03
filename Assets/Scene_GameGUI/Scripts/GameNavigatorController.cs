using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameNavigatorController : MonoBehaviour {

    // Use this for initialization
    public Text score;
	public Text maxHealth;
    void Awake()
    {
		maxHealth.text = PlayerController.maxBlood + "";
        score.text = PlayerController.money + "";
		int star1 = PlayerController.star_lv1;
		if (star1 == 0) {
			GameObject.FindGameObjectWithTag ("Star Level 1").GetComponent<Animator> ().SetTrigger ("Rate 0");
		} else if (star1 == 1) {
			GameObject.FindGameObjectWithTag ("Star Level 1").GetComponent<Animator> ().SetTrigger ("Rate 1");
		} else if (star1 == 2) {
			GameObject.FindGameObjectWithTag ("Star Level 1").GetComponent<Animator> ().SetTrigger ("Rate 2");
		} else if (star1 == 3) {
			GameObject.FindGameObjectWithTag ("Star Level 1").GetComponent<Animator> ().SetTrigger ("Rate 3");
		}

        star1 = PlayerController.star_lv2;
        if (star1 == 0)
        {
            GameObject.FindGameObjectWithTag("Star Level 2").GetComponent<Animator>().SetTrigger("Rate 0");
        }
        else if (star1 == 1)
        {
            GameObject.FindGameObjectWithTag("Star Level 2").GetComponent<Animator>().SetTrigger("Rate 1");
        }
        else if (star1 == 2)
        {
            GameObject.FindGameObjectWithTag("Star Level 2").GetComponent<Animator>().SetTrigger("Rate 2");
        }
        else if (star1 == 3)
        {
            GameObject.FindGameObjectWithTag("Star Level 2").GetComponent<Animator>().SetTrigger("Rate 3");
        }

        star1 = PlayerController.star_lv3;
        if (star1 == 0)
        {
            GameObject.FindGameObjectWithTag("Star Level 3").GetComponent<Animator>().SetTrigger("Rate 0");
        }
        else if (star1 == 1)
        {
            GameObject.FindGameObjectWithTag("Star Level 3").GetComponent<Animator>().SetTrigger("Rate 1");
        }
        else if (star1 == 2)
        {
            GameObject.FindGameObjectWithTag("Star Level 3").GetComponent<Animator>().SetTrigger("Rate 2");
        }
        else if (star1 == 3)
        {
            GameObject.FindGameObjectWithTag("Star Level 3").GetComponent<Animator>().SetTrigger("Rate 3");
        }


    }

    public void _OnClickBuyButton()
    {
        GameObject coin = GameObject.FindGameObjectWithTag("CoinIcon");
        coin.GetComponent<Animator>().SetBool("isBuy", true);
        GameObject health = GameObject.FindGameObjectWithTag("HealthIcon");
        health.GetComponent<Animator>().SetBool("isBuy", true);

        if(PlayerController.money >= 100)
        {
            PlayerController.money -= 100;
            PlayerController.maxBlood += 1f;
            score.text = PlayerController.money + "";
			maxHealth.text = PlayerController.maxBlood + "";
        }
        
    }

    public void _SelectLevelButton()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        if(button.tag == "Door1"){
            SceneManager.LoadScene("Scene1");
        }
        else if (button.tag == "Door2"){
				SceneManager.LoadScene("Scene2");
        }
        else if (button.tag == "Door3"){
				SceneManager.LoadScene("Scene3");
        }
    }

    public void _BackButton()
    {
        SceneManager.LoadScene("GameMenu");
    }

}
