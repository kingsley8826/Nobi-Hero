using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBlood2 : MonoBehaviour {

    private Slider bloodSlider;

    public float blood;

    // Use this for initialization
    void Awake()
    {
        blood = PlayerController.maxBlood;
        GetPrefereces();
    }

    // Update is called once per frame
    void Update()
    {
        bloodSlider.value = blood;
    }
    void GetPrefereces()
    {
        bloodSlider = GameObject.Find("PlayerBlood Slider").GetComponent<Slider>();
        bloodSlider.minValue = 0f;
        bloodSlider.maxValue = blood;
        bloodSlider.value = bloodSlider.maxValue;
    }
}
