using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Quiz
{
    public interface IQuestionData
    {
        string Key { get; set; }
    }

    [Serializable]
    public struct QuestionData
    {
        public Question[] Questions;
    }

    [Serializable]
    public struct Question
    {
        [field: SerializeField]
        public string Key { get; set; }

        public string Text;
        public float Duration;

        public AnswerData[] Answers;
    }
}
