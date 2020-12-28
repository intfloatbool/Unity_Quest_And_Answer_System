namespace _QuestionAnswersModule.Scripts.Base
{
    public interface IAnswer<T>
    {
        T GetAnswerData();
        bool IsEqualsTo(IAnswer<T> anotherAnswer);
    }
}