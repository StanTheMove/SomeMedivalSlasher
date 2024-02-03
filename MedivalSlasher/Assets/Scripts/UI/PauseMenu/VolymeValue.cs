using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolymeValue : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 1f;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void SetVolyme(float vol)
    {
        musicVolume = vol;
    }
}
