using System;
using System.Collections.Generic;
using System.Windows.Input;
using QuizEarth.Models;
using QuizEarth.Views.User.PopUps;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
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
                GetQuestions();
                SetProperty(ref _countryId, value);
            }
        }

        public ICommand AnswerTapCommand { get; set; }

        public float Percentage { get; set; }


        private void OnAnswerTap(object obj)
        {
            var question = GetNextQuestion();

            //Quiz is over, so save results and show victory screen.
            if (question == null)
            {
                //Save result from user
                var lastUserId = SecureStorage.GetAsync("LastUserId").Result;
                int.TryParse(lastUserId, out var userId);
                Int32.TryParse(CountryId, out int countryId);

                var scoreboard = new Scoreboard()
                {
                    UserId = userId,
                    CountryId = countryId,
                    Score = Score
                };

                App.Database.SaveScore(scoreboard);

                //Display Victory Screen
                var victoryPopUp = new VictoryPopUpPage(userId,countryId, Score);
                PopupNavigation.Instance.PushAsync(victoryPopUp);

                return;
            }

            // Keep track of already answered questions so they won't be asked again
            Questions.Add(Question);

            CheckResult(obj.ToString());

            Question = question;
        }

        

        private Question GetNextQuestion()
        {
            int index = Questions.IndexOf(Question);

            //Quiz is over, end it)
            if (index == 9)
            {
                return null;
            }
            else
            {
                return Questions[index + 1];
            }
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
            if (CountryId != null)
            {
                Int32.TryParse(CountryId, out int countryId);
                var questions = await App.Database.GetRandomQuestions(countryId);
                Questions = new List<Question>(questions);
                Question = Questions[0];
            }
        }
    }
}