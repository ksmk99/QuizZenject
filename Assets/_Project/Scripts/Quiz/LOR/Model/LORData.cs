using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz
{
    [Serializable]
    public struct LORData
    {
        public LOR[] Data;
    }

    [Serializable]
    public class LOR : IQuestionData
    {
        [field: SerializeField]
        public string[] Keys { get; set; }
        public float ExitDelay = 5f;
        public LORPart[] Parts;
    }

    [Serializable]
    public class LORPart
    {
        public string Text;
        public float Duration;
        public AudioClip AudioClip;
        public float ClipDelay = 1f;
    }
}


