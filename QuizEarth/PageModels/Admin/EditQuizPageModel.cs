using QuizEarth.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace QuizEarth.PageModels.Admin
{
    [QueryProperty("CountryId", "countryId")]
    public class EditQuizPageModel : BaseViewModel
    {
        private string countryId;

        public ICommand AddQuestionCommand { get; set; }

        public ICommand SaveQuizCommand { get; set; }

        public ICommand DeleteQuestionCommand { get; set; }

        public EditQuizPageModel()
        {
            Questions = new ObservableCollection<Question>();

            Int32.TryParse(CountryId, out int countryId);

            FillQuestions(countryId);

            SaveQuizCommand = new Command(OnSaveAnswers);
            AddQuestionCommand = new Command(OnAddQuestion);
            DeleteQuestionCommand = new Command(OnDeleteQuestion);
        }

        private void OnDeleteQuestion(object obj)
        {
            if (!(obj is Question question))
            {
                return;
            }

            // Must be minimum 10 questions
            if (Questions.Count == 10)
            {
                 UserDialogs.Instance.AlertAsync("Sorry, the minimum is 10 questions",
                    "Sorry", "OK");
                return;
            }

            Questions.Remove(question);
        }

        private void OnAddQuestion()
        {
            Int32.TryParse(CountryId, out int countryId);
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
            set
            {
                countryId = Uri.UnescapeDataString(value);
                SetProperty(ref countryId, value);
            }
        }

        private void OnSaveAnswers()
        {
            Int32.TryParse(CountryId, out int countryId);

            //Validate Quiz

            //Update quiz status if valid
            App.Database.UpdateQuizStatus(true, countryId);

            //Save Questions
            App.Database.SaveQuestions(countryId, Questions);
        }

        public ObservableCollection<Question> Questions { get; set; }
    }
}