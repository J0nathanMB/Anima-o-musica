using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDefaultIndividualIntensity : MonoBehaviour
{
    private Dictionary<Toggle, bool> toggles;
    private Dictionary<Slider, float> sliders;
    
    private Dictionary<Toggle, bool> savedToggles;
    private Dictionary<Slider, float> savedSliders;

    private bool lastToogle = true;

    private void Awake()
    {
        toggles = new Dictionary<Toggle, bool>();
        sliders = new Dictionary<Slider, float>();
        
        savedToggles = new Dictionary<Toggle, bool>();
        savedSliders = new Dictionary<Slider, float>();
    }

    private void Start()
    {
        foreach (var toggle in GetComponentsInChildren<Toggle>())
        {
            toggles.Add(toggle, toggle.isOn);
        }
        
        foreach (var slider in GetComponentsInChildren<Slider>())
        {
            sliders.Add(slider, slider.value);
        }
    }

    public void SetDefault()
    {
        foreach (var toggle in toggles)
        {
            toggle.Key.isOn = toggle.Value;
        }
        
        foreach (var slider in sliders)
        {
            slider.Key.value = slider.Value;
        }
    }

    public void ToggleAllToggles()
    {
        lastToogle = !lastToogle;
        foreach (var toggle in toggles)
        {
            toggle.Key.isOn = lastToogle;
        }
    }

    public void SaveState()
    {
        savedToggles = new Dictionary<Toggle, bool>();
        savedSliders = new Dictionary<Slider, float>();
        
        foreach (var toggle in GetComponentsInChildren<Toggle>())
        {
            savedToggles.Add(toggle, toggle.isOn);
        }
        
        foreach (var slider in GetComponentsInChildren<Slider>())
        {
            savedSliders.Add(slider, slider.value);
        }
    }

    public void ApplyState()
    {
        foreach (var toggle in savedToggles)
        {
            toggle.Key.isOn = toggle.Value;
        }
        
        foreach (var slider in savedSliders)
        {
            slider.Key.value = slider.Value;
        }
    }

}
