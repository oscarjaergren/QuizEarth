using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using QuizEarth.Helpers;
using QuizEarth.Models;
using SQLite;

namespace QuizEarth.Data
{
    public class QuizEarthDatabase
    {
        private static readonly Lazy<SQLiteAsyncConnection> LazyInitializer = new Lazy<SQLiteAsyncConnection>(() => new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags));

        private static bool _initialized;

        public QuizEarthDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        private static SQLiteAsyncConnection Database => LazyInitializer.Value;

        internal Task<User> GetUserByUserName(string userName)
        {
            return Database.Table<User>().Where(user => user.UserName == userName).FirstOrDefaultAsync();
        }

        internal Task<User> GetUserByUserId(int userId)
        {
            return Database.Table<User>().Where(user => user.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task InitializeAsync()
        {
            if (!_initialized)
                if (Database.TableMappings.All(m => m.MappedType.Name != typeof(Question).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Question)).ConfigureAwait(false);
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Country)).ConfigureAwait(false);
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(User)).ConfigureAwait(false);
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Scoreboard)).ConfigureAwait(false);

                    _initialized = true;
                }
        }


        internal Task<List<Scoreboard>> GetScoreboard()
        {
            return Database.Table<Scoreboard>().ToListAsync();
        }

        public Task<int> InsertUser(User user)
        {
            return Database.InsertAsync(user);
        }

        internal void SaveQuestions(int countryId, ObservableCollection<Question> questions)
        {
            throw new NotImplementedException();
        }

        internal Task<List<Country>> GetAllCountries()
        {
            return Database.Table<Country>().ToListAsync();
        }

        public Task<List<Question>> GetItemsAsync()
        {
            return Database.Table<Question>().ToListAsync();
        }

        public Task<List<Question>> GetQuestions(int countryId)
        {
            //SELECT * FROM table WHERE id IN (SELECT id FROM table ORDER BY RANDOM() LIMIT x) 
            return Database.Table<Question>().ToListAsync();


            //return Database.Table<Question>().Where(x => true).OrderBy(x => Guid.NewGuid()).Take(10).ToListAsync();
        }

        internal Task UpdateQuizStatus(int countryId, bool hasQuiz)
        {
            return Database.UpdateAsync("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        internal Task<User> GetUser(string username, string password)
        {
            //SELECT * FROM login_details WHERE username = ? AND password = ?
            return Database.Table<User>().Where(user => user.UserName == username && user.Password == password).FirstOrDefaultAsync();
        }

        public Task<Question> GetItemAsync(int id)
        {
            return Database.Table<Question>().Where(i => i.CountryId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Question item)
        {
            if (item.CountryId != 0)
                return Database.UpdateAsync(item);
            return Database.InsertAsync(item);
        }

        public Task<int> InsertCountries(List<Country> countries)
        {
            return Database.InsertAllAsync(countries);
        }

        public Task<int> InsertQuestions(List<Question> questions)
        {
            return Database.InsertAllAsync(questions);
        }

        public Task<int> DeleteItemAsync(Question item)
        {
            return Database.DeleteAsync(item);
        }
    }
}