namespace QuizEarth.Models
{
    public class Country
    {
        public Country(string id, string name)
        {
            (Id, Name) = (id, name);
        }

        public string Id { get; }

        public string Name { get; }
    }
}