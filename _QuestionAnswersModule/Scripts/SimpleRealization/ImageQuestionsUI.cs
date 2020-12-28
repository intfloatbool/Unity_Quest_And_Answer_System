using System.Collections.Generic;
using _QuestionAnswersModule.Scripts.Base;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace _QuestionAnswersModule.Scripts.SimpleRealization
{
    public class ImageQuestionsUI : MonoBehaviour
    {
        [SerializeField] private ImageQuestionData[] _questions;
        
        [Space]
        [SerializeField] private TextMeshProUGUI _questionNameText;
        [SerializeField] private TextMeshProUGUI _questionDescrText;
        [SerializeField] private Image _questionImage;
        [SerializeField] private Transform _answersRoot;
        [SerializeField] private Button _answerButtonPrefab;
        
        private List<Button> _currentButtons;
        private IQuestion<string> _currentQuestion;
        private int _currentQuestionIndex = -1;
        
        private void Awake()
        {
            Assert.IsTrue(_questions.Length > 0, "_questions.Length > 0");
            
            Assert.IsNotNull(_questionNameText, "_questionNameText != null");
            Assert.IsNotNull(_questionDescrText, "_questionDescrText != null");
            Assert.IsNotNull(_questionImage, "_questionImage != null");
            Assert.IsNotNull(_answersRoot, "_answersRoot != null");
            Assert.IsNotNull(_answerButtonPrefab, "_answerButtonPrefab != null");

            _currentButtons = new List<Button>(5);
        }

        private void Start()
        {
            GoToNextQuestion();
        }

        public void GoToNextQuestion()
        {
            _currentQuestionIndex++;

            if (_currentQuestionIndex > _questions.Length - 1)
            {
                _currentQuestionIndex = 0;
            }

            _currentButtons.ForEach(b => Destroy(b.gameObject));
            _currentButtons.Clear();
            
            var questionData = _questions[_currentQuestionIndex];
            _currentQuestion = questionData.ConvertToQuestion();
            var answers = _currentQuestion.GetAnswers();
            foreach (var answer in answers)
            {
                CreateButtonForAnswer(answer);
            }

            _currentQuestion.OnAnswerFailed += OnAnswerFailed;
            _currentQuestion.OnAnswerSuccess += OnAnswerSuccess;

            _questionNameText.text = _currentQuestion.QuestName;
            _questionDescrText.text = _currentQuestion.QuestDescription;
            _questionImage.sprite = questionData.QuestSprite;
        }

        private void OnAnswerFailed(IAnswer<string> answer)
        {
            Debug.Log("<color=red>You are wrong!</color>");
        }

        private void OnAnswerSuccess(IAnswer<string> answer)
        {
            Debug.Log("<color=green>GOOD JOB!</color>");
            GoToNextQuestion();
        }

        private void CreateButtonForAnswer(IAnswer<string> answer)
        {
            var btnInstance = Instantiate(_answerButtonPrefab, _answersRoot);
            btnInstance.gameObject.SetActive(true);
            var btnText = btnInstance.GetComponentInChildren<TextMeshProUGUI>();
            if (btnText != null)
            {
                btnText.text = answer.GetAnswerData();
            }
            
            btnInstance.onClick.AddListener(() =>
            {
                _currentQuestion.CheckAnswer(answer);
            });
            
            _currentButtons.Add(btnInstance);
        }
    }
}
