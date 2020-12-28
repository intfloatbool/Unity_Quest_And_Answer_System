using System;
using System.Collections.Generic;

namespace _QuestionAnswersModule.Scripts.Base
{
    public interface IQuestion<T>
    {
        string QuestName { get; }
        string QuestDescription { get; }
        IAnswer<T> GetCorrectAnswer();
        IReadOnlyCollection<IAnswer<T>> GetAnswers();

        event Action<IAnswer<T>> OnAnswerFailed;
        event Action<IAnswer<T>> OnAnswerSuccess;

        void CheckAnswer(IAnswer<T> answer);

        bool IsCorrectAnswer(IAnswer<T> answer);
    }
}
