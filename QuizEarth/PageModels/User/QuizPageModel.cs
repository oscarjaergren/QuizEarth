using System.Collections.ObjectModel;
using System.Windows.Input;
using QuizEarth.Models;
using Xamarin.Forms;

namespace QuizEarth.PageModels.User
{
    public class QuizPageModel : BaseViewModel
    {
        private Question _question;

        public QuizPageModel()
        {
            AnsweredQuestions = new ObservableCollection<Question>();

            GetQuestions();

            AnswerTapCommand = new Command<string>(OnAnswerTap);
        }

        public ObservableCollection<Question> AnsweredQuestions { get; }

        public Question Question
        {
            get => _question;
            set
            {
                _question = value;
                OnPropertyChanged();
            }
        }

        public ICommand AnswerTapCommand { get; set; }

        private void OnAnswerTap(object obj)
        {
            var question = GetNextQuestion();

            // Keep track of already answered questions so they won't be asked again
            AnsweredQuestions.Add(Question);

            CheckResult(obj.ToString());
            
            Question = question;
        }

        private static Question GetNextQuestion()
        {
            var question = new Question
            {
                Answer1 = "Paris",
                Answer2 = "London",
                Answer3 = "Göteborg",
                Answer4 = "Malmö",
                CorrectAnswer = "London",
                QuestionText = "What is the capital of England?",
                CountryId = 2,
                ID = 2
            };
            return question;
        }

        private void CheckResult(string answer)
        {
            //Check if correct answer
            if (answer == Question.CorrectAnswer)
            {
                Score++;
            }
        }

        public int Score { get; set; }

        private async void GetQuestions()
        {
            Question = await App.Database.GetItemAsync(1);


            GetMockQuestions();
        }

        private void GetMockQuestions()
        {
            var question = new Question
            {
                Answer1 = "Uppsala",
                Answer2 = "Stockholm",
                Answer3 = "Göteborg",
                Answer4 = "Malmö",
                CorrectAnswer = "Stockholm",
                QuestionText = "What is the capital of Sweden?",
                CountryId = 1,
                ID = 1
            };


            Question = question;
        }
    }
}