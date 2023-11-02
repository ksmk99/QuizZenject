using System.Collections.Generic;
using Zenject;

namespace Quiz
{
    public class PLayerData : IInitializable, IPLayerData
    {
        public string KEY { get; private set; }

        private Dictionary<int, IQuestionData> questionsDict;

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
                    questionsDict.Add(key.GetHashCode(), item);
                }
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
    }
}
