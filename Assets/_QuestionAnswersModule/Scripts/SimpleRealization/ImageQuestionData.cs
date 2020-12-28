using System.Linq;
using _QuestionAnswersModule.Scripts.Base;
using _QuestionAnswersModule.Scripts.Static;
using UnityEngine;

namespace _QuestionAnswersModule.Scripts.SimpleRealization
{
    [CreateAssetMenu(fileName = "ImageQuestionData", menuName = "QASample/ImageQuestionData", order = 0)]
    public class ImageQuestionData : ScriptableObject
    {
        [SerializeField] private string _questName;
        
        [TextArea]
        [SerializeField] private string _questDescription;

        [SerializeField] private Sprite _questSprite;
        public Sprite QuestSprite => _questSprite;

        [SerializeField] private StringAnswerData _correctAnswer;
        [SerializeField] private StringAnswerData[] _answers;

        [Space]
        [SerializeField] private bool _isShuffleAnswers = true;
        
        public IQuestion<string> ConvertToQuestion()
        {
            var correctAnswer = _correctAnswer.ConvertToAnswer();
            var answers = _answers.Select(a => a.ConvertToAnswer()).ToList();
            
            if(_isShuffleAnswers)
                answers.Shuffle();
            
            return new StringQuestion(_questName, _questDescription, answers, correctAnswer);
        }
    }
}