using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderWrapper : MonoBehaviour
{
    public int blendIndex;
    
    public float floatValue { set; get; }
    public bool boolValue { set; get; }

    private void Start()
    {
        if (GetComponent<Slider>() != null)
        {
            floatValue = GetComponent<Slider>().value;
        }

        if (GetComponent<Toggle>() != null)
        {
            boolValue = GetComponent<Toggle>().isOn;
        }
    }
}
