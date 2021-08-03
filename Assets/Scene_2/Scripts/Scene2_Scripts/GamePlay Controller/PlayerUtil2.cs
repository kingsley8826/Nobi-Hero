using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerUtil2 : MonoBehaviour
{

    private Slider utilSlider;

    public float maxUtil = 10;
    public float utilValue;

    // Use this for initialization
    void Awake()
    {
        GetPrefereces();
    }

    // Update is called once per frame
    void Update()
    {
        utilSlider.value = utilValue;
        if(utilValue < maxUtil)
        {
            utilValue += 1 * Time.deltaTime;
        }
    }
    void GetPrefereces()
    {
        utilValue = maxUtil;
        utilSlider = GameObject.Find("Util Slider").GetComponent<Slider>();
        utilSlider.minValue = 0f;
        utilSlider.maxValue = maxUtil;
        utilSlider.value = utilSlider.maxValue;
    }
}
