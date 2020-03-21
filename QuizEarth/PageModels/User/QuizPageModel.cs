using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using QuizEarth.Models;
using Xamarin.Forms;

namespace QuizEarth.PageModels.User
{
    [QueryProperty("CountryId", "_countryId")]
    public class QuizPageModel : BaseViewModel
    {
        private string _countryId;

        private Question _question;

        public QuizPageModel()
        {
            Questions = new List<Question>();

            GetQuestions();

            AnswerTapCommand = new Command<string>(OnAnswerTap);
        }

        public List<Question> Questions { get; set; }

        public Question Question
        {
            get => _question;
            set
            {
                _question = value;
                OnPropertyChanged();
            }
        }

        public string CountryId
        {
            get => _countryId;
            set
            {
                _countryId = Uri.UnescapeDataString(value);
                SetProperty(ref _countryId, value);
            }
        }

        public ICommand AnswerTapCommand { get; set; }

        public float Percentage { get; set; }


        private void OnAnswerTap(object obj)
        {
            var question = GetNextQuestion();

            // Keep track of already answered questions so they won't be asked again
            Questions.Add(Question);

            CheckResult(obj.ToString());

            Question = question;
        }

        private Question GetNextQuestion()
        {
            int index = Questions.IndexOf(Question);
            return Questions[index + 1];
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
            var questions = await App.Database.GetQuestions(1);
            Questions = new List<Question>(questions);

            Question = Questions[0];
        }
    }
}