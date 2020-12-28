using _QuestionAnswersModule.Scripts.Base;
using UnityEngine;

namespace _QuestionAnswersModule.Scripts.SimpleRealization
{
    [CreateAssetMenu(fileName = "StringAnswerData", menuName = "QASample/StringAnswerData", order = 0)]
    public class StringAnswerData : ScriptableObject
    {
        [SerializeField] private string _answer;
        
        public IAnswer<string> ConvertToAnswer()
        {
            return new StringAnswer(_answer);
        }
    }
}