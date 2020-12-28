using _QuestionAnswersModule.Scripts.Base;

namespace _QuestionAnswersModule.Scripts.SimpleRealization
{
    public class StringAnswer : IAnswer<string>
    {
        private string _data;

        public StringAnswer(string data)
        {
            _data = data;
        }

        public string GetAnswerData() => _data;

        public bool IsEqualsTo(IAnswer<string> anotherAnswer)
        {
            return anotherAnswer.GetAnswerData().Equals(_data);
        }
    }
}
