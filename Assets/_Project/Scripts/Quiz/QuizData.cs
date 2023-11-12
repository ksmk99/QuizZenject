using Quiz;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class QuizData : ScriptableObject
{
    public AnswerSound[] AnswerSounds;
    public LORData LOR;
    public QuestionData Questions;
}

[Serializable]
public struct AnswerSound
{
    public string Text;
    public AnswerSoundType Type;
    public AudioClip AudioClip;
}

public enum AnswerSoundType
{
    None,
    Correct,
    Incorrect
}
