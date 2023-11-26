using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMusicModel 
{
    public AudioClip MainMenuAudio;
    public AudioClip QuizAudio;

    public readonly float NormalValue;
    public readonly float MutedValue;

    public BackMusicModel(AudioClip mainMenuAudio, AudioClip quizAudio, float normalValue, float mutedValue)
    {
        this.MainMenuAudio = mainMenuAudio;
        this.QuizAudio = quizAudio;
        NormalValue = normalValue;
        MutedValue = mutedValue;
    }
}
