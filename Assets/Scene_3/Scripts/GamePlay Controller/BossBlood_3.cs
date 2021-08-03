using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossBlood_3 : MonoBehaviour {

    private Slider bloodSlider;

    public float blood;

    // Use this for initialization
    void Awake()
    {
        GetPrefereces();
    }

    // Update is called once per frame
    void Update()
    {
        bloodSlider.value = blood;
    }
    void GetPrefereces()
    {
        bloodSlider = GameObject.Find("BossBlood Slider 3").GetComponent<Slider>();
        bloodSlider.minValue = 0f;
        bloodSlider.maxValue = blood;
        bloodSlider.value = bloodSlider.maxValue;
    }
}
