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

        private void GetQuestions()
        {
            throw new NotImplementedException();
        }   

        public List<CountryQuestionsList> QuestionsList { get; set; }
    }
}