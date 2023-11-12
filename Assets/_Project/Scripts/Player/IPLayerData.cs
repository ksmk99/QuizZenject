namespace Quiz
{
    public interface IPLayerData
    {
        string KEY { get; }

        IQuestionData GetQuestionData();
        bool TrySetKey(string key);
        void Initialize();
        AnswerSound GetAnswerSound(AnswerSoundType type);
    }
}