using QuizEarth.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizEarth.PageModels.Admin
{
    [QueryProperty("CountryId", "countryId")]
    public class AdminPageModel
    {
        private string countryId;

        public ICommand AnswerTapCommand { get; set; }

        public AdminPageModel()
        {
            Questions = new List<Question>();

            FillQuestions(1);

            AnswerTapCommand = new Command<string>(OnAnswerTap);
        }

        private void FillQuestions(int countryId)
        {
            for (int i = 0; i < 20; i++)
            {
                var question = new Question(countryId);
                Questions.Add(question);
            }
        }

        public string CountryId
        {
            get => countryId;
            set => countryId = Uri.UnescapeDataString(value);
        }

        private void OnAnswerTap(object obj)
        {

           //Move ahead in carouselList
        }

        public Question CurrentQuestion { get; set; }

        public List<Question> Questions { get; set; }

    }
}