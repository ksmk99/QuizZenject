using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LORView : MonoBehaviour
{
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private Slider timerSlider;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private AudioSource audioSource;

    public void SetMessage(string message, AudioClip audioClip)
    {
        messageText.text = message;
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    public void UpdateTimer(float time, float duration)
    {
        timerSlider.value = time / duration;
        timerText.text = $"{Mathf.RoundToInt(duration - time)}s";
    }
}
