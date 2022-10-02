using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupMusicOptions : MonoBehaviour
{
    private Dropdown _dropdown;

    private void Awake()
    {
        _dropdown = GetComponent<Dropdown>();
    }

    void Start()
    {
        foreach (var label in MusicChanger.Instance.GetMusicsLabels())
        {
            _dropdown.options.Add(new Dropdown.OptionData(label));
        }
    }

}
