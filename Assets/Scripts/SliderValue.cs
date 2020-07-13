using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    [SerializeField] Text textComponent;

    public void SetSliderValue(float sliderValue)
    {
        textComponent.text = Mathf.Round(sliderValue).ToString();
    }

}
