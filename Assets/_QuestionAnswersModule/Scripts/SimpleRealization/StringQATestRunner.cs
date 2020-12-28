using UnityEngine;
using UnityEngine.Assertions;

namespace _QuestionAnswersModule.Scripts.SimpleRealization
{
    public class StringQATestRunner : MonoBehaviour
    {
        private void Start()
        {
            var correctAnswer1 = new StringAnswer("Berlin");
            var answers1 = new StringAnswer[]
            {
                new StringAnswer("London"),
                new StringAnswer("Paris"),
                correctAnswer1,
                new StringAnswer("Moscow")
            };

            var quest1Name = "The capital of Germany";
            var quest1Description = string.Empty;

            var quest1 = new StringQuestion(
                quest1Name,
                quest1Description,
                answers1,
                correctAnswer1);
            
            Assert.IsFalse(quest1.IsCorrectAnswer(answers1[0]));
            Assert.IsFalse(quest1.IsCorrectAnswer(answers1[1]));
            Assert.IsFalse(quest1.IsCorrectAnswer(answers1[3]));
            Assert.IsTrue(quest1.IsCorrectAnswer(correctAnswer1));

            quest1.OnAnswerFailed += (answer) =>
            {
                Debug.Log($"Answer {answer.GetAnswerData()} <color=red>is not correct!</color>.");
            };

            quest1.OnAnswerSuccess += (answer) =>
            {
                Debug.Log($"Answer {answer.GetAnswerData()} <color=green>is correct!</color> Success!");
            };

            foreach (var answer in answers1)
            {
                quest1.CheckAnswer(answer);
            }
        }
    }
}
