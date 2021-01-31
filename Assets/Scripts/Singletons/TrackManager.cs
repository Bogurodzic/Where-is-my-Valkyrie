using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager :  GenericSingletonClass<TrackManager>
{
    private AudioSource _audio;
    public AudioClip mainTheme;
    public AudioClip epilogueTheme;
    public AudioClip choosingValkyrie;
    
    void Start()
    {
        LoadComponents();
        PlayMainTheme();
    }

    private void LoadComponents()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void PlayMainTheme()
    {
        _audio.Stop();
        _audio.clip = mainTheme;
        _audio.loop = true;
        _audio.Play();
    }
    
    public void PlayEpilogueTheme()
    {
        _audio.Stop();
        _audio.clip = epilogueTheme;
        _audio.loop = true;
        _audio.Play();
    }
    
    public void PlayChoosingValkyrie()
    {
        _audio.Stop();
        _audio.clip = choosingValkyrie;
        _audio.loop = true;
        _audio.Play();
    }

    void Update()
    {
        
    }
}
