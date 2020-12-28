using System;
using System.Collections.Generic;
using _QuestionAnswersModule.Scripts.Base;

namespace _QuestionAnswersModule.Scripts.SimpleRealization
{
    public class StringQuestion : IQuestion<string>
    {
        public string QuestName { get; }
        public string QuestDescription { get; }
        
        public event Action<IAnswer<string>> OnAnswerFailed;
        public event Action<IAnswer<string>> OnAnswerSuccess;

        private ICollection<IAnswer<string>> _answers;
        private IAnswer<string> _correctAnswer;
        
        public StringQuestion(string questName, string questDescription, ICollection<IAnswer<string>> answers,
            IAnswer<string> correctAnswer)
        {
            QuestName = questName;
            QuestDescription = questDescription;
            _answers = answers;
            _correctAnswer = correctAnswer;
        }

        public IAnswer<string> GetCorrectAnswer() => _correctAnswer;

        public IReadOnlyCollection<IAnswer<string>> GetAnswers() => 
            (IReadOnlyCollection<IAnswer<string>>) _answers;
        
        public void CheckAnswer(IAnswer<string> answer)
        {
            if (_correctAnswer.IsEqualsTo(answer))
            {
                OnAnswerSuccess?.Invoke(answer);
            }
            else
            {
                OnAnswerFailed?.Invoke(answer);
            }
        }

        public bool IsCorrectAnswer(IAnswer<string> answer)
        {
            return _correctAnswer.IsEqualsTo(answer);
        }
    }
}
