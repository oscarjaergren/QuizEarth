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

        public ICommand OnAddLastQuestionCommand { get; set; }

        public ICommand AnswerTapCommand { get; set; }


        public AdminPageModel()
        {
            Questions = new List<Question>();

            FillQuestions(1);

            AnswerTapCommand = new Command(OnSaveAnswers);
            OnAddLastQuestionCommand = new Command(OnAddLastQuestion);

        }

        private void OnAddLastQuestion()
        {
            Int32.TryParse("-105", out int countryId);
            var question = new Question(countryId);
            Questions.Add(question);
        }

        private void FillQuestions(int countryId)
        {
            for (int i = 0; i < 10; i++)
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

        private void OnSaveAnswers()
        {

           
            //Save coountry


            //Save questions
            //App.Database.SaveQuestions(CountryId., Questions);
        }

        public Question CurrentQuestion { get; set; }

        public List<Question> Questions { get; set; }

    }
}