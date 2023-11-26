using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMusicView : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource backAudioSource;

    public void SetVolume(float value)
    {
        if(audioSource == null)
        {
            throw new NullReferenceException();
        }

        audioSource.volume = value;
    }

    public void SetClip(AudioClip mainMenuAudio)
    {
        backAudioSource.clip = mainMenuAudio;
        backAudioSource.Play();
    }
}
