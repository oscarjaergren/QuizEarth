using QuizEarth.PageModels;
using SQLite;

namespace QuizEarth.Models
{
    public class Country : BaseViewModel
    {
        private string name;
        private string countryId;

        public Country(string countryId, string name)
        {
            (CountryId, Name) = (countryId, name);
        }

        public Country()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string CountryId
        {
            get => countryId;
            set => SetProperty(ref countryId, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public CountryStatus CountryStatus { get; set; }

        public bool HasQuiz { get; set; }
    }

    public enum CountryStatus
    {
        NotAttempted = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        MaxScore = 4,
    }
}