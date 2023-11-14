using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Quiz
{
    public class PLayerData : IInitializable, IPLayerData
    {
        public string KEY { get; private set; }

        private Dictionary<int, IQuestionData> questionsDict;
        private Dictionary<AnswerSoundType, List<AnswerSound>> soundsDict;

        private readonly QuizData data;

        public PLayerData(QuizData data)
        {
            this.data = data;
        }

        public void Initialize()
        {
            questionsDict = new Dictionary<int, IQuestionData>();
            foreach (var item in data.LOR.Data)
            {
                foreach (var key in item.Keys)
                {
                    var newKey = key.ToLower();
                    questionsDict.Add(key.GetHashCode(), item);
                }
            }

            soundsDict = new Dictionary<AnswerSoundType, List<AnswerSound>>();
            foreach (var sound in data.AnswerSounds)
            {
                if(!soundsDict.ContainsKey(sound.Type))
                {
                    soundsDict.Add(sound.Type, new List<AnswerSound>());
                }

                soundsDict[sound.Type].Add(sound);
            }
        }

        public bool TrySetKey(string key)
        {
            int index = key.GetHashCode();
            if (questionsDict.ContainsKey(index))
            {
                KEY = key;
                return true;
            }

            return false;
        }

        public IQuestionData GetQuestionData()
        {
            int index = KEY.GetHashCode();
            return questionsDict[index];
        }

        public AnswerSound GetAnswerSound(AnswerSoundType type)
        {
            return soundsDict[type][Random.Range(0, soundsDict[type].Count - 1)];
        }
    }
}
