using SQLite;

namespace QuizEarth.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public User(string userName, string password, bool isAdmin)
        {
            UserName = userName;
            Password = password;
            IsAdmin = isAdmin;
        }

        public User()
        {

        }
    }
}
