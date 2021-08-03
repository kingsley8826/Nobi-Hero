using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishScript_1 : MonoBehaviour {

    public float increaseDiffInterval;
    public Canvas CanvasSuccess;


    void Start()
    {

        StartCoroutine(increaseDiff());
    }
	void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Goal")
        {
            CanvasSuccess.gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("PauseButton").SetActive(false);
            int star1;
			if (GameObject.Find ("GamePlay Controller").GetComponent<PlayerBlood1> ().blood >= PlayerController.maxBlood * 0.8) {
				star1 = 3;
			} else if (GameObject.Find ("GamePlay Controller").GetComponent<PlayerBlood1> ().blood >= PlayerController.maxBlood * 0.5) {
				star1 = 2;
			} else if (GameObject.Find ("GamePlay Controller").GetComponent<PlayerBlood1> ().blood >= PlayerController.maxBlood * 0.2) {
				star1 = 1;
			} else {
				star1 = 0;
			}
			PlayerController.setStar_lv1 (star1);
            PlayerController.setCurrentStar(star1);
            Scene1Controller.instance.finishScene();
            this.GetComponent<Move_1>().speed = 0;
            if (star1 == 0)
            {
                GameObject.FindGameObjectWithTag("CurrentStar").GetComponent<Animator>().SetTrigger("Rate 0");
            }
            else if (star1 == 1)
            {
                GameObject.FindGameObjectWithTag("CurrentStar").GetComponent<Animator>().SetTrigger("Rate 1");
            }
            else if (star1 == 2)
            {
                GameObject.FindGameObjectWithTag("CurrentStar").GetComponent<Animator>().SetTrigger("Rate 2");
            }
            else if (star1 == 3)
            {
                GameObject.FindGameObjectWithTag("CurrentStar").GetComponent<Animator>().SetTrigger("Rate 3");
            }
        }

    }

    IEnumerator increaseDiff()
    {
        Scene1Controller.instance.interval -= 0.05f;
        yield return new WaitForSeconds(increaseDiffInterval);
        StartCoroutine(increaseDiff());
    }
}
