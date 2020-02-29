using SQLite;

namespace QuizEarth.ViewModels
{
    public class CountryQuestionsList : BaseViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Question { get; set; }
            
        public int CountryId { get; set; }
        public string CorrectAnswer { get; set; }

        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }

    }
}