using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicChanger : MonoBehaviour
{
    
    AudioSource audioSource;
    
    [SerializeField] private AudioClip[] musics;
    
    [Tooltip("Same order as audioClip inputs above.")]
    [SerializeField] private String[] musicsLabels;

    private static MusicChanger _instance;
    public static MusicChanger Instance => _instance;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ChangeMusic(0);
    }

    public void ChangeMusic(int index)
    {
        audioSource.clip = musics[index];
        audioSource.Play();
    }

    public String[] GetMusicsLabels()
    {
        return musicsLabels;
    }
}
