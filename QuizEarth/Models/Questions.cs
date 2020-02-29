using SQLite;

namespace QuizEarth.Models
{
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string QuestionText { get; set; }
            
        public int CountryId { get; set; }

        public string CorrectAnswer { get; set; }   

        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }

    }
}