using SQLite;

namespace QuizEarth.Models
{
    public class Country
    {
        public Country(string id, string name)
        {
            (Id, Name) = (id, name);
        }

        [PrimaryKey, AutoIncrement]
        public string Id { get; }

        public string Name { get; }

        public CountryStatus CountryStatus { get; set; }
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