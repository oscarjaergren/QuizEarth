using QuizEarth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizEarth.ViewModels
{
    public class QuizPageModel
    {
        public QuizPageModel()
        {
            GetQuestions();
        }

        private async void GetQuestions()
        {
            QuestionsList = await App.Database.GetItemsAsync();
        }   

        public List<Question> QuestionsList { get; set; }
    }
}